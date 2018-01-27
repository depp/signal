using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameManager instance = null;

	public bool radioPuzzleDone = false;
	public bool letterPuzzleDone = false;
	public bool glassPuzzleDone = false;
	public bool candlePuzzleDone = false;

	//Final lock members
	public bool topLayer = false;
	public bool midLayer = false;
	public bool botLayer = false;
	public bool finalPuzzleDone = false;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}
}
