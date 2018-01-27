using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Radio script controls the behavior of the radio itself and does not
/// need to be attached to some particular object, it is just a part of the scene.
/// </summary>
public class Radio : MonoBehaviour {
	public int channelCount;
	public event Action channelChanged;
	public AnimationCurve switchCurve;
	public float switchTime;

	private int _channel;
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
			_startFraction = _curFraction;
			_endFraction = (float)value / (float)(channelCount - 1);
			_time = 0.0f;
			OnChannelChanged();
		}
	}

	/// <summary>
	/// Gets the radio channel as a fraction from 0..1.
	/// </summary>
	bool _moving;
	float _startFraction, _endFraction, _curFraction, _time;
	public float fraction {
		get { return _curFraction; }
	}

	public void Start() {
		if (channelCount < 2) {
			Debug.LogErrorFormat("Want at least two channels for Radio");
		}
	}

	public void Update() {
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

	public void NextChannel() {
		if (_moving) {
			return;
		}
		var c = channel + 1;
		if (c >= channelCount) {
			c = 0;
		}
		channel = c;
	}

	void OnChannelChanged() {
		var f = channelChanged;
		if (f != null) {
			f();
		}
	}
}
