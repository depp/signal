using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterChurch : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (GameManager.EnteredChurch == false) {
			Report ();
			Dialogue.instance.PlayScript ("Entering Church", Report);
		}

		if (GameManager.finalPuzzleDone) {
			Dialogue.instance.PlayScript ("Lock Encounter", Finish);
		}
	}

	void Report(){
		GameManager.EnteredChurch = true;
	}

	void Finish(){
		SceneChanger.ChangeScene ("End");

	}
}
