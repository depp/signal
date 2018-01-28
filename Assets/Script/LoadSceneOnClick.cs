using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour {
	public string sceneName;

	void OnMouseDown() {
		SceneChanger.ChangeScene(sceneName);
	}
}
