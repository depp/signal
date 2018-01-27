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
			var f = channelChanged;
			if (f != null) {
				f();
			}
		}
	}

	/// <summary>
	/// Gets the radio channel as a fraction from 0..1.
	/// </summary>
	public float fraction {
		get {
			return (float)channel / (float)(channelCount - 1);
		}
	}

	public void Start() {
		if (channelCount < 2) {
			Debug.LogErrorFormat("Want at least two channels for Radio");
		}
	}

	public void NextChannel() {
		var c = channel + 1;
		if (c >= channelCount) {
			c = 0;
		}
		channel = c;
	}
}
