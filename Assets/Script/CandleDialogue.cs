using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleDialogue : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (GameManager.CandleFind == false) {
			Dialogue.instance.PlayScript ("Discover Candle Puzzle", ReportFind);
		}
		if (GameManager.CandleFinish == false && GameManager.candlePuzzleDone == true) {
			Dialogue.instance.PlayScript ("Complete Candle Puzzle", ReportFind);
		}
	}

	void ReportFind(){
		GameManager.CandleFind = true;
	}
	void ReportFinish(){
		GameManager.CandleFinish = true;
	}
}
