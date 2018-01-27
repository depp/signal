using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleHandler : MonoBehaviour {
	public Candle[] candles;
	public int[] currentCandleInput = new int[3];

	public int[] correctAnswer;
	public bool answered = false;

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
			}
		}
	}
}
