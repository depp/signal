using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
	public int sceneCode;

	void OnMouseDown(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		SceneManager.LoadScene (sceneCode);
	}
}
