using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	public static bool radioPuzzleDone = false;
	public static bool letterPuzzleDone = false;
	public static bool glassPuzzleDone = false;
	public static bool candlePuzzleDone = false;
	public static bool hasLetter = false;

	//Final lock members
	public static bool topLayer = false;
	public static bool midLayer = false;
	public static bool botLayer = false;
	public static bool finalPuzzleDone = false;

	//Stained Glass states
	public static int[] glassState = {0,0,0};

	//Letter
	public static int letterState = -1;

	//Candle states
	public static int[] candleStates = {0,0,0};

	//Final lock
	public static int[] lockStates = {0,0,0,0,0,0,0,0,0};

	//Dialog checks
	public static bool EnteredChurch = false;
	public static bool FinalDoor = false;
	public static bool FinalDoorSecond = false;
	public static bool LetterFind = false;
	public static bool LetterFinish = false;
	public static bool CandleFind = false;
	public static bool CandleFinish = false;
	public static bool WindowFind = false;
	public static bool WindowFinish = false;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	void Update(){
		int[] solution = { 2, 6, 4 };
		bool test = true;

		for (int i = 0; i < 3; i++) {
			if (glassState [i] != solution [i]) {
				test = false;
			}
		}

		if(test){
			glassPuzzleDone = true;
			Debug.Log ("woom");
		}
	}
}
