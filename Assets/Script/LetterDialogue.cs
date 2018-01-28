using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDialogue : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (GameManager.LetterFind == false) {
			Dialogue.instance.PlayScript ("Discover Letter Puzzle",ReportFind);
		}

		if (GameManager.LetterFinish && !GameManager.LetterFinish) {
			Dialogue.instance.PlayScript ("Complete Letter Puzzle", ReportFinish);
		}
	}

	void ReportFind(){
		GameManager.LetterFind = true;
	}
	void ReportFinish(){
		GameManager.LetterFinish = true;
	}
}
