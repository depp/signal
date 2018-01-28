using UnityEngine;
using UnityEngine.EventSystems;

public class LoadSceneOnClick : MonoBehaviour, IPointerDownHandler {
	public string sceneName;

	public void OnPointerDown(PointerEventData data) {
		SceneChanger.ChangeScene(sceneName);
	}
}
