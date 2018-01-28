using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SceneChanger : MonoBehaviour {
	private static SceneChanger _instance;
	public AnimationCurve curve;
	public float transitionTime = 0.5f;
	public Color fadeColor = Color.black;

	private Image _image;
	private string _target;
	private float _time;

	void Awake() {
		if (_instance != null) {
			Debug.LogError("Two SceneChangers");
		}
		_instance = this;
	}

	void Start() {
		gameObject.SetActive(false);
	}

	void OnDestroy() {
		if (this == _instance) {
			_instance = null;
		}
	}

	void Update() {
		_time += Time.deltaTime;
		if (_time >= transitionTime) {
			gameObject.SetActive(false);
			SceneManager.LoadScene(_target);
			return;
		}
		Color color = fadeColor;
		color.a = curve.Evaluate(_time / transitionTime);
		_image.color = color;
	}

	public static void ChangeScene(string target) {
		_instance.ChangeSceneImpl(target);
	}

	void ChangeSceneImpl(string target) {
		_target = target;
		_image = GetComponent<Image>();
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		gameObject.SetActive(true);
	}
}
