using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
	public int sceneCode;
	public CursorChangeOverObject cursorChanger;

	void OnMouseDown(){
		cursorChanger.ReturnToDefault ();
		SceneManager.LoadScene (sceneCode);
	}
}
