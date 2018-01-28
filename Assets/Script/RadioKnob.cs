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

	void Start() {
		baseRotation = transform.localRotation;
		radio.update += RadioUpdate;
	}

	public void OnPointerDown(PointerEventData data) {
		radio.NextChannel();
	}

	void RadioUpdate() {
		transform.localRotation = baseRotation * Quaternion.AngleAxis(knobRotation * radio.dialPosition, Vector3.forward);
	}
}
