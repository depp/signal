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

	// Private state.
	int _channel; // Channel we are tuned in to.
	bool _moving; // Needle / dial currently moving.
	float _startFraction, _endFraction, _curFraction, _time; // Needle / dial movement.
	bool _tunedIn; // Are we currently tuned in to the right channel?
	int _solutionProgress; // Once we listen to clip 0, this increments to 0 -> 1, etc. Resets every cycle.

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
		// Index of the current clip playing.
		int clipIndex = ClipIndex();
		// We wrapped around, reset the solution lock.
		if (_solutionProgress > clipIndex + 1) {
			_solutionProgress = 0;
		}
		// Channel that this clip plays on.
		int clipChannel = clipIndex % channelCount;
		bool tunedIn = clipChannel == channel;
		if (tunedIn && clipIndex == _solutionProgress) {
			_solutionProgress++;
			if (_solutionProgress == this.clipTimes.Length) {
				Solve();
			}
		}
		if (tunedIn == _tunedIn) {
			return;
		}
		_tunedIn = tunedIn;
		voice.mute = !tunedIn;
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
