using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleHandler : MonoBehaviour {
	public Candle[] candles;
	public int[] currentCandleInput = new int[3];

	public int[] correctAnswer;
	public bool answered = false;

	void Start(){
		for (int i = 0; i < 3; i++) {
			currentCandleInput [i] = GameManager.candleStates [i];
		}
	}

	void Update(){

		for (int i = 0; i < candles.Length; i++) {
			currentCandleInput [i] = candles [i].currentState;
		}

		if (!answered) {
			bool test = true;
			for (int i = 0; i < currentCandleInput.Length; i++) {
				if (currentCandleInput [i] != correctAnswer [i]) {
					test = false;
				}
			}
			if (test) {
				Debug.Log ("puzzle complete");
				answered = true;
				GameManager.candlePuzzleDone = true;
			}
		}

		if (GameManager.candlePuzzleDone && !answered) {
			answered = true;
			candles [0].currentState = correctAnswer[0];
			candles [1].currentState = correctAnswer[1];
			candles [2].currentState = correctAnswer[2];
		}

		for (int i = 0; i < 3; i++) {
			GameManager.candleStates [i] = currentCandleInput [i];
		}
	}
}
