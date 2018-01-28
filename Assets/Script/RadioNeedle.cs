using UnityEngine;

/// <summary>
/// RadioNeedle controls the movement of the needle on the radio.
/// </summary>
public class RadioNeedle : MonoBehaviour {
	public enum Type {
		Channel,
		SignalLock,
	}

	// Editor properties.
	public Radio radio;
	public Transform needleTarget; // Farthes position needle will go.
	public Type type;

	// Private state.
	private Vector2 minPos, maxPos;

	void Start() {
		minPos = transform.localPosition;
		maxPos = needleTarget.position;
		if (transform.parent != null) {
			maxPos = transform.parent.InverseTransformPoint(maxPos);
		}
		radio.update += RadioUpdate;
	}

	void RadioUpdate() {
		float frac;
		switch (type) {
			case Type.Channel:
				frac = radio.dialPosition;
				break;
			case Type.SignalLock:
				frac = radio.signalLock;
				break;
			default:
				Debug.LogError("Invalid needle type");
				return;
		}
		transform.localPosition = Vector2.Lerp(minPos, maxPos, frac);
	}
}
