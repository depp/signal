﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	public static bool radioPuzzleDone = false;
	public static bool letterPuzzleDone = false;
	public static bool glassPuzzleDone = false;
	public static bool candlePuzzleDone = false;

	//Final lock members
	public static bool topLayer = false;
	public static bool midLayer = false;
	public static bool botLayer = false;
	public static bool finalPuzzleDone = false;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	//Functions to finish each puzzle
	void FinishRadioPuzzle(){
		radioPuzzleDone = true;
	}
	void FinishLetterPuzzle(){
		letterPuzzleDone = true;
	}
	void FinishGlassPuzzle(){
		glassPuzzleDone = true;
	}
	void FinishCandlePuzzle(){
		candlePuzzleDone = true;
	}
	void FinishTopLayer(){
		topLayer = true;
	}
	void FinishMidLayer(){
		midLayer = true;
	}
	void FinishBotLayer(){
		botLayer = true;
	}
	void FinishFinalPuzzle(){
		finalPuzzleDone = true;
	}
}