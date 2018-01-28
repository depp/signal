using UnityEngine;
using UnityEngine.EventSystems;

public class LoadSceneOnClick : MonoBehaviour {
	public string sceneName;

	public void OnPointerDown(PointerEventData data) {
		SceneChanger.ChangeScene(sceneName);
	}
}
