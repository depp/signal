using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
	public int sceneCode;
	private Texture2D defaultCursor;

	void OnMouseDown(){
		Cursor.SetCursor (defaultCursor,Vector2.zero,CursorMode.Auto);
		SceneManager.LoadScene (sceneCode);
	}
}
