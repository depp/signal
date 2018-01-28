using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candle : MonoBehaviour, IPointerDownHandler {
	public CandleStates states;
	public int currentState = 0;
	SpriteRenderer sprite;
	public CandleHandler handler;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update(){
		sprite.sprite = states.candles [currentState];
	}

	public void OnPointerDown(PointerEventData data) {
		if (handler.answered == false) {
			if (currentState < states.candles.Length - 1) {
				currentState++;
			} else {
				currentState = 0;
			}
		}
	}
}
