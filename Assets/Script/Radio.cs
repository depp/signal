using System;
using UnityEngine;

/// <summary>
/// The Radio script controls the behavior of the radio itself and does not
/// need to be attached to some particular object, it is just a part of the scene.
/// </summary>
public class Radio : MonoBehaviour {
	class Value {
		readonly float _switchTime;
		readonly AnimationCurve _switchCurve;
		bool _moving;
		float _start, _end, _cur, _time;

		public Value(float switchTime, AnimationCurve switchCurve) {
			_switchTime = switchTime;
			_switchCurve = switchCurve;
		}

		public float value {
			get { return _cur; }
		}

		public void Set(float value) {
			if (_moving) {
				_end = value;
			} else {
				_cur = value;
			}
		}

		public void MoveTo(float value) {
			_moving = true;
			_start = _cur;
			_end = value;
			_time = 0.0f;
		}

		public void Update() {
			if (!_moving) {
				return;
			}
			_time += Time.deltaTime;
			if (_time >= _switchTime) {
				_moving = false;
				_cur = _end;
			} else {
				_cur = Mathf.Lerp(_start, _end, _switchCurve.Evaluate(_time / _switchTime));
			}
		}
	}

	// Editor properties.
	public int channelCount = 4;
	public AnimationCurve switchCurve;
	public float switchTime = 0.2f;
	public float deadTime = 0.2f; // Time after NextChannel() where clicks are ignored.
	public float[] clipTimes; // The time, in seconds, of the start of each clip in the speech.
	public AudioSource noise;
	public AudioSource voice;
	public float solutionTolerance = 0.3f; // +/- tolerance for timing of solution.
	public GameObject sceneTransition;

	// Private state.
	float _deadTimeRemaining;
	int _channel; // Channel we are tuned in to.
	Value _dial, _signalLock; // Needle / dial movement.
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
			_dial.MoveTo(_channel / (float)(channelCount-1));
		}
	}

	/// <summary>
	/// Gets the radio channel as a fraction from 0..1.
	/// </summary>
	public float dialPosition {
		get { return _dial.value; }
	}

	/// <summary>
	/// Get the signal lock as a fraction 0..1, 1 = puzzle solved.
	/// </summary>
	public float signalLock {
		get { return _signalLock.value; }
	}

	public event Action update;

	void Start() {
		if (channelCount < 2) {
			Debug.LogErrorFormat("Want at least two channels for Radio");
		}
		_dial = new Value(switchTime, switchCurve);
		_signalLock = new Value(switchTime, switchCurve);
	}

	void Update() {
		_deadTimeRemaining -= Time.deltaTime;
		float pos = voice.time;
		float solutionPos = clipTimes[clipTimes.Length - 1];
		// Check to see if we have solved the puzzle.
		if (_solutionIndex == clipTimes.Length && pos > solutionPos) {
			Solve();
			return;
		}
		// Figure out which clip we are playing.
		if (pos < clipTimes[0]) {
			_clipIndex = 0;
		} else if (_clipIndex < clipTimes.Length - 1 && pos > clipTimes[_clipIndex]) {
			_clipIndex++;
		}
		// Figure out if we are tuned in to the right channel.
		bool isTuned = (_clipIndex % channelCount) == channel;
		voice.mute = !isTuned;
		// Check the solution progress.
		if (pos < solutionTolerance && isTuned) {
			_solutionIndex = 1;
		} else if (_solutionIndex > 0) {
			float clipStart = _clipIndex > 0 ? clipTimes[_clipIndex - 1] : 0.0f;
			float clipEnd = clipTimes[_clipIndex];
			// Only check in middle of clip.
			bool isInMiddle = clipStart + solutionTolerance < pos && pos < clipEnd - solutionTolerance;
			if (isInMiddle) {
				if (isTuned) {
					_solutionIndex = _clipIndex + 1;
				} else {
					_solutionIndex = 0;
					_signalLock.MoveTo(0.0f);
				}
			}
		}
		if (_solutionIndex > 0) {
			_signalLock.Set(pos / solutionPos);
		}
		_dial.Update();
		_signalLock.Update();
		var f = update;
		if (f != null) {
			f();
		}
	}

	/// <summary>
	/// Tune the radio to the next channel.
	/// </summary>
	public void NextChannel() {
		if (_deadTimeRemaining > 0.0f) {
			return;
		}
		var c = channel + 1;
		if (c >= channelCount) {
			c = 0;
		}
		channel = c;
		_deadTimeRemaining = deadTime;
	}

	public void Solve() {
		voice.Stop();
		noise.Stop();
		enabled = false;
		Dialogue.instance.PlayScript("Radio Solved", SolveDone);
	}

	void SolveDone() {
		gameObject.SetActive(false);
		sceneTransition.SetActive(true);
	}
}
