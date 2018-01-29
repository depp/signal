using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDialogue : MonoBehaviour {
	void Update () {
		if (!GameManager.WindowFind) {
			ReportFind ();
			Dialogue.instance.PlayScript ("Discover Stained Glass Puzzle", ReportFind);
		}
		if (GameManager.glassPuzzleDone && !GameManager.WindowFinish) {
			GameManager.WindowFinish = true;
			Dialogue.instance.PlayScript ("Complete Stained Glass Puzzle", ReportFinish);
		}
	}

				void ReportFind(){
		GameManager.WindowFind = true;
				}
				void ReportFinish(){
		GameManager.WindowFinish = true;
				}
}
