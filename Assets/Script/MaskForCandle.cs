using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaskForCandle : MonoBehaviour, IPointerDownHandler {
	public BoxCollider2D candleColliders;
	public BoxCollider2D wallColliders;

	public void OnPointerDown (PointerEventData eventData)
	{
		wallColliders.enabled = true;
		candleColliders.enabled = true;
		gameObject.SetActive (false);
	}
}
