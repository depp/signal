using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaskForCandle : MonoBehaviour, IPointerDownHandler {
	public BoxCollider2D colliders;

	public void OnPointerDown (PointerEventData eventData)
	{
		colliders.enabled = true;
		gameObject.SetActive (false);
	}
}
