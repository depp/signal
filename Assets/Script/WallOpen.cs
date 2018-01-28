using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WallOpen : MonoBehaviour, IPointerDownHandler {
	public GameObject WallMask;
	public BoxCollider2D colliders;
	public BoxCollider2D otherOpen;

	public void OnPointerDown (PointerEventData eventData)
	{
		otherOpen.enabled = false;
		colliders.enabled = false;
		WallMask.SetActive (true);
	}

}
