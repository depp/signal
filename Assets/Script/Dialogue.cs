using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Dialogue : MonoBehaviour, IPointerDownHandler {
	static Dialogue _instance;

	public static Dialogue instance {
		get { return _instance; }
	}

	class Line {
		public string audio;
		public string text;
	}
	class Script {
		public Line[] lines;
	}

	// Editor properties.
	public Text text;

	// Private state.
	AudioSource _source;
	Dictionary<string, Script> _scripts;
	Line[] _currentScript;
	Action _action;
	int _currentLine;

	void Start() {
		_instance = this;
		_source = GetComponent<AudioSource>();
		gameObject.SetActive(false);
	}

	public void OnPointerDown(PointerEventData data) {
		PlayLine(_currentLine + 1);
	}

	/// <summary>
	/// Plays a dialogue script.
	/// </summary>
	/// <param name="script">Name of the script to play.</param>
	/// <param name="action">Action to execute when the script finishes.</param>
	public void PlayScript(string script, Action action) {
		if (_currentScript != null) {
			Debug.LogErrorFormat("Tried to run two scripts.");
			return;
		}
		LoadScript();
		Script scriptObj;
		if (!_scripts.TryGetValue(script.ToLowerInvariant(), out scriptObj)) {
			Debug.LogErrorFormat("No such script: {0}", script);
			return;
		}
		gameObject.SetActive(true);
		_currentScript = scriptObj.lines;
		_action = action;
		PlayLine(0);
	}

	void PlayLine(int number) {
		if (_currentScript == null) {
			Debug.LogErrorFormat("No script playing");
			return;
		}
		if (number >= _currentScript.Length) {
			_currentScript = null;
			_currentLine = 0;
			gameObject.SetActive(false);
			_action();
			return;
		}
		Line line = _currentScript[number];
		if (line.audio != null) {
			AudioClip clip = Resources.Load<AudioClip>(line.audio);
			if (clip == null) {
				Debug.LogErrorFormat("No such audio clip: {0}", line.audio);
			} else {
				_source.clip = clip;
				_source.Play();
			}
		}
		text.text = line.text;
		_currentLine = number;
	}

	void LoadScript() {
		if (_scripts != null) {
			return;
		}
		_scripts = new Dictionary<string, Script>();
		TextAsset data = Resources.Load<TextAsset>("Dialogue Script");
		if (data == null) {
			Debug.LogError("Could not load dialogue");
			return;
		}
		int lineno = 0;
		string scriptName = null;
		List<Line> scriptLines = new List<Line>();
		char[] fieldSplits = new char[]{':'};
		using (StringReader reader = new StringReader(data.text)) {
			while (true) {
				string line = reader.ReadLine();
				if (line == null) {
					break;
				}
				lineno++;
				line = line.TrimEnd();
				if (line.Length == 0) {
					continue;
				}
				switch (line[0]) {
					case '#':
						break;
					case '%':
						if (scriptName != null) {
							_scripts[scriptName] = new Script{lines = scriptLines.ToArray()};
						}
						scriptLines.Clear();
						scriptName = line.Substring(1).TrimStart().ToLowerInvariant();
						if (scriptName.Length == 0) {
							Debug.LogErrorFormat("Invalid dialogue: line {0}", lineno);
						}
						break;
					default:
						string[] fields = line.Split(fieldSplits, 2);
						if (fields.Length != 2) {
							Debug.LogErrorFormat("Invalid dialogue: line {0}", lineno);
							continue;
						}
						string audio = fields[0].Trim(), text = fields[1].Trim();
						if (audio.Length == 0) {
							audio = null;
						}
						scriptLines.Add(new Line{ audio = audio, text = text });
						break;
				}
			}
		}
		if (scriptName != "") {
			_scripts[scriptName] = new Script{lines = scriptLines.ToArray()};
		}
	}

	public static void Nothing(){

	}
}
