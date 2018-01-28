using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// RadioKnob controls the movement and interaction with the knob on the radio.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class RadioKnob : MonoBehaviour, IPointerDownHandler {
	// Editor properties.
	public Radio radio;
	public float knobRotation;

	// Private state.
	private Quaternion baseRotation;
	private SpriteRenderer spriteRenderer;

	void Start() {
		baseRotation = transform.localRotation;
		radio.channelChanged += ChannelDidChange;
	}

	public void OnPointerDown(PointerEventData data) {
		radio.NextChannel();
	}

	void ChannelDidChange() {
		transform.localRotation = baseRotation * Quaternion.AngleAxis(knobRotation * radio.fraction, Vector3.forward);
	}
}
