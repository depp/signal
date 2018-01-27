using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChangeOverObject : MonoBehaviour {
	public static Texture2D defaultCursor;
	public Texture2D changeTo;
	public Vector2 hotSpot = Vector2.zero;
	public CursorMode cursorMode = CursorMode.Auto;

	void OnMouseEnter () {
		Cursor.SetCursor (changeTo, hotSpot, cursorMode);
	}
	void OnMouseExit () {
		ReturnToDefault ();
	}
	public void ReturnToDefault(){
		Cursor.SetCursor (defaultCursor, hotSpot, cursorMode);
	}
}
