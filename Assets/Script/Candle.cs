using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {
	public CandleStates states;
	public int currentState = 0;
	SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown () {
		if (currentState < states.candles.Length - 1) {
			currentState++;
			sprite.sprite = states.candles [currentState];
		} else {
			currentState = 0;
			sprite.sprite = states.candles [0];
		}
	}
}
