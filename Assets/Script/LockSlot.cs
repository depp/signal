using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockSlot : MonoBehaviour {
	public int currentPosition = 0;
	public Sprite[] visuals;
	SpriteRenderer sprite;
	public LockHandler handler;

	void Start(){
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update(){
		sprite.sprite = visuals [currentPosition];
	}

	public void OnPointerDown(PointerEventData data) {
		if (handler.completed != true) {
			if (currentPosition < visuals.Length - 1) {
				currentPosition++;
			} else {
				currentPosition = 0;
			}
		}
	}
}
