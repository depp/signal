using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewOfDoor : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.FinalDoor) {
			Dialogue.instance.PlayScript ("First Lock Encounter", Report);
		}
	}

	void Report(){
		GameManager.FinalDoor = true;
	}
}
