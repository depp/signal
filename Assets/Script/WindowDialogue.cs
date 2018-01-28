using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDialogue : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.WindowFind) {
			Dialogue.instance.PlayScript ("Discover Stained Glass Puzzle", ReportFind);
		}
		if (GameManager.glassPuzzleDone && !GameManager.WindowFinish) {
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
