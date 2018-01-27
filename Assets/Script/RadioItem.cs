using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// RadioItem is the radio on the ground that you can pick up.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class RadioItem : MonoBehaviour, IPointerDownHandler {
	// Editor properties.
	public GameObject radio;
	public GameObject backgroundWithRadio;
	public GameObject backgroundSansRadio;

	public void OnPointerDown(PointerEventData data) {
		backgroundWithRadio.SetActive(false);
		backgroundSansRadio.SetActive(true);
		radio.SetActive(true);
	}
}
