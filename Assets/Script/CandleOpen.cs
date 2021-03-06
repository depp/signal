﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CandleOpen : MonoBehaviour, IPointerDownHandler {
	public GameObject CandleMask;
	public BoxCollider2D colliders;
	public BoxCollider2D otherOpen;

	public void OnPointerDown (PointerEventData eventData)
	{
		colliders.enabled = false;
		otherOpen.enabled = false;
		CandleMask.SetActive (true);
	}
}
