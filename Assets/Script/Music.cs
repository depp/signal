using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	public static Music instance = null;

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
