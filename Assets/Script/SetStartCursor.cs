using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartCursor : MonoBehaviour {
	public Texture2D cursor;

	public Vector2 hotSpot = Vector2.zero;
	public CursorMode cursorMode = CursorMode.Auto;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor (cursor,hotSpot,cursorMode);
		Destroy (gameObject);
	}
}
