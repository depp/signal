using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterLockHandler : MonoBehaviour {
	public bool finished = false;
	public LockHandler[] locks;

	void Update(){
		if (!finished) {
			bool test = true;
			for (int i = 0; i < locks.Length; i++) {
				if (locks [i].completed == false) {
					test = false;
				}
			}
			if (test) {
				finished = true;
				GameManager.finalPuzzleDone = true;
				Debug.Log ("Woot!");
			}
		}
	}
}
