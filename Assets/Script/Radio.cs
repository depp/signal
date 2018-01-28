using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Radio script controls the behavior of the radio itself and does not
/// need to be attached to some particular object, it is just a part of the scene.
/// </summary>
public class Radio : MonoBehaviour {
	// Editor properties.
	public int channelCount = 4;
	public event Action channelChanged;
	public AnimationCurve switchCurve;
	public float switchTime = 0.2f;
	public float deadTime = 0.2f; // Time after NextChannel() where clicks are ignored.
	public float[] clipTimes; // The time, in seconds, of the start of each clip in the speech.
	public AudioSource noise;
	public AudioSource voice;
	public float solutionTolerance = 0.3f; // +/- tolerance for timing of solution.

	// Private state.
	int _channel; // Channel we are tuned in to.
	bool _moving; // Needle / dial currently moving.
	float _startFraction, _endFraction, _curFraction, _time; // Needle / dial movement.
	int _clipIndex; // Clip currently being broadcast.
	int _solutionIndex = 1; // Position in solution 0..clipCount, clipCount = solved.

	/// <summary>
	/// Gets the current radio channel number, 0..channelCount-1.
	/// </summary>
	public int channel {
		get { return _channel; }
		set {
			if (value == _channel) {
				return;
			}
			_channel = value;
			_moving = true;
			MoveTo((float)value / (float)(channelCount - 1));
			OnChannelChanged();
		}
	}

	/// <summary>
	/// Gets the radio channel as a fraction from 0..1.
	/// </summary>

	public float fraction {
		get { return _curFraction; }
	}

	public void Start() {
		if (channelCount < 2) {
			Debug.LogErrorFormat("Want at least two channels for Radio");
		}
	}

	public void Update() {
		UpdateFraction();
		UpdateAudio();
	}

	/// <summary>
	/// Tune the radio to the next channel.
	/// </summary>
	public void NextChannel() {
		if (_moving && _time < deadTime) {
			return;
		}
		var c = channel + 1;
		if (c >= channelCount) {
			c = 0;
		}
		channel = c;
		if (_solutionIndex > 0) {
			if (_solutionIndex == clipTimes.Length) {
				_solutionIndex = 0;
				return;
			}
			float curTime = voice.time;
			float targetTime = clipTimes[_solutionIndex - 1];
			float delta = Mathf.Abs(targetTime - curTime);
			bool ok = delta < solutionTolerance;
			// Debug.LogFormat("OK={0}, delta={1}", ok, delta);
			if (!ok) {
				_solutionIndex = 0;
			} else {
				_solutionIndex++;
			}
		}
	}
		
	// UpdateFraction updates the dial & knob position.
	void UpdateFraction() {
		if (!_moving) {
			return;
		}
		_time += Time.deltaTime;
		if (_time >= switchTime) {
			_moving = false;
			_curFraction = _endFraction;
		} else {
			_curFraction = Mathf.Lerp(_startFraction, _endFraction, switchCurve.Evaluate(_time / switchTime));
		}
		OnChannelChanged();
	}

	// UpdateAudio updates the audio sources to match the radio channel.
	void UpdateAudio() {
		if (voice.time < clipTimes[0]) {
			if (_solutionIndex == clipTimes.Length) {
				Solve();
			}
			if (_clipIndex != 0) {
				_clipIndex = 0;
				_solutionIndex = 1;
			}
		} else if (_clipIndex < clipTimes.Length) {
			float switchTime = clipTimes[_clipIndex];
			if (voice.time > switchTime) {
				_clipIndex++;
				Debug.LogFormat("clipIndex {0}, solutionIndex {1}, time {2}", _clipIndex, _solutionIndex, switchTime);
				if (_clipIndex == clipTimes.Length && _solutionIndex == clipTimes.Length) {
					Solve();
				}
			}
		}
		int clipChannel = _clipIndex % channelCount;
		voice.mute = clipChannel != _channel;
	}

	// ClipIndex returns the index of the current audio clip playing.
	int ClipIndex() {
		float voiceTime = voice.time;
		for (int i = 1; i < clipTimes.Length; i++) {
			if (voiceTime < clipTimes[i]) {
				return i - 1;
			}
		}
		return clipTimes.Length - 1;
	}

	// MoveTo moves the dial & knob to a target position.
	void MoveTo(float target) {
		_startFraction = _curFraction;
		_endFraction = target;
		_time = 0.0f;
	}

	// OnChannelChanged sends the channelChanged event.
	void OnChannelChanged() {
		var f = channelChanged;
		if (f != null) {
			f();
		}
	}

	public void Solve() {
		voice.Stop();
		noise.Stop();
		Dialogue.instance.PlayScript("Radio Solved");
	}
}
