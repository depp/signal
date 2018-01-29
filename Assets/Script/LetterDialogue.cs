using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDialogue : MonoBehaviour {
	
	void Update(){
		if (GameManager.LetterFind == false) {
			ReportFind ();
			Dialogue.instance.PlayScript ("Discover Letter Puzzle", ReportFind);
		}
		if (GameManager.letterPuzzleDone && !GameManager.LetterFinish) {
		GameManager.LetterFinish = true;
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
