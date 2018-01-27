using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHandler : MonoBehaviour {
	public LockSlot[] locks;
	public int[] inputCombo;
	public int[] correctCombo;

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
			}
		}
	}
}
