using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WallOpen : MonoBehaviour, IPointerDownHandler {
	public GameObject WallMask;
	public BoxCollider2D colliders;

	public void OnPointerDown (PointerEventData eventData)
	{
		colliders.enabled = false;
		WallMask.SetActive (true);
	}

}
