using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	public static Music instance = null;

	// Use this for initialization
	void Start () {
		instance = this;
		DontDestroyOnLoad (gameObject);
	}
	void Update(){
		if (instance != this) {
			Destroy (gameObject);
		}
	}
}
