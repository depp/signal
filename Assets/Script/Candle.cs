using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {
	public CandleStates states;
	public int currentState = 0;
	SpriteRenderer sprite;
	public CandleHandler handler;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown () {
		if (handler.answered == false) {
			if (currentState < states.candles.Length - 1) {
				currentState++;
			} else {
				currentState = 0;
			}
		}
		sprite.sprite = states.candles [currentState];
	}
}
