using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterChurch : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (GameManager.EnteredChurch == false) {
			Dialogue.instance.PlayScript ("Entering Church", Report);
		}
	}

	void Report(){
		GameManager.EnteredChurch = true;
	}
}
