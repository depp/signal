using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CursorChangeOverObject : MonoBehaviour {
	public Texture2D changeTo;
	public Vector2 hotSpot = Vector2.zero;
	public CursorMode cursorMode = CursorMode.Auto;

	void OnMouseEnter () {
		Cursor.SetCursor (changeTo, hotSpot, cursorMode);
	}
	void OnMouseExit () {
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}
}
