using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalClick : MonoBehaviour {

	void OnMouseDown(){
		Dialogue.instance.PlayScript ("End Dialog", Cut);
	}

	public static void Cut(){
		SceneChanger.ChangeScene ("Credits");
	}
}
