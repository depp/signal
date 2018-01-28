using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewOfDoor : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.FinalDoor) {
			Report ();
			Dialogue.instance.PlayScript ("First Lock Encounter", Report);
		}

		if (GameManager.finalPuzzleDone && !GameManager.FinalDoorSecond) {
			GameManager.FinalDoorSecond = true;
			Dialogue.instance.PlayScript("Lock Encounter", MoveOne);
		}
	}

	void Report(){
		GameManager.FinalDoor = true;
	}
	void MoveOne(){
		SceneChanger.ChangeScene ("End");
	}
}
