using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SceneChanger : MonoBehaviour {
	private static SceneChanger _instance;
	private static bool _doFadeIn;
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
		_image = GetComponent<Image>();
		if (!_doFadeIn) {
			gameObject.SetActive(false);
		}
	}

	void OnDestroy() {
		if (this == _instance) {
			_instance = null;
		}
	}

	void Update() {
		_time += Time.deltaTime;
		if (_time >= transitionTime) {
			if (_doFadeIn) {
				_doFadeIn = false;
				gameObject.SetActive(false);
			} else {
				_doFadeIn = true;
				SceneManager.LoadScene(_target);
			}
			return;
		}
		Color color = fadeColor;
		float frac = _time / transitionTime;
		if (_doFadeIn) {
			frac = 1.0f - frac;
		}
		color.a = curve.Evaluate(frac);
		_image.color = color;
	}

	public static void ChangeScene(string target) {
		_instance.ChangeSceneImpl(target);
	}

	void ChangeSceneImpl(string target) {
		_target = target;
		_image.color = Color.clear;
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		gameObject.SetActive(true);
	}
}
