using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHandler : MonoBehaviour {
	public LockSlot[] locks;
	public int[] inputCombo;
	public int[] correctCombo;
	public int position;

	public bool completed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 3; i++) {
			inputCombo [i] = locks [i].currentPosition;
		}

		if (!completed) {
			bool test = true;
			for (int i = 0; i < 3; i++) {
				if (inputCombo [i] != correctCombo [i]) {
					test = false;
				}
			}
			if (test) {
				Debug.Log ("Finished!");
				completed = true;
				if (position == 0) {
					GameManager.topLayer = true;
				} else if (position == 1) {
					GameManager.midLayer = true;
				} else if (position == 2) {
					GameManager.botLayer = true;
				}
			}
		}

		if (position == 0 && GameManager.topLayer) {
			locks [0].currentPosition = correctCombo [0];
			locks [1].currentPosition = correctCombo [1];
			locks [2].currentPosition = correctCombo [2];
		}else if (position == 1 && GameManager.midLayer) {
			locks [0].currentPosition = correctCombo [0];
			locks [1].currentPosition = correctCombo [1];
			locks [2].currentPosition = correctCombo [2];
		}else if (position == 2 && GameManager.botLayer) {
			locks [0].currentPosition = correctCombo [0];
			locks [1].currentPosition = correctCombo [1];
			locks [2].currentPosition = correctCombo [2];
		}
	}
}
