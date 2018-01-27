using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RadioNeedle controls the movement of the needle on the radio.
/// </summary>
public class RadioNeedle : MonoBehaviour {
	// Editor properties.
	public Radio radio;
	public Transform needleTarget; // Farthes position needle will go.

	// Private state.
	private Vector2 minPos, maxPos;
	private SpriteRenderer spriteRenderer;

	void Start() {
		minPos = transform.localPosition;
		maxPos = needleTarget.position;
		if (transform.parent != null) {
			maxPos = transform.parent.InverseTransformPoint(maxPos);
		}
		radio.channelChanged += ChannelDidChange;
	}

	void ChannelDidChange() {
		transform.localPosition = Vector2.Lerp(minPos, maxPos, radio.fraction);
	}
}
