using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class CursorChangeOverObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public Texture2D changeTo;
	public Vector2 hotSpot = Vector2.zero;

	public void OnPointerEnter(PointerEventData eventData) {
		Cursor.SetCursor(changeTo, hotSpot, CursorMode.Auto);
	}

	public void OnPointerExit(PointerEventData eventData) {
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
