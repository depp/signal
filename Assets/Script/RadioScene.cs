using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScene : MonoBehaviour {
	public Texture2D defaultCursor;
	public GameObject background;
	public GameObject background2;
	public GameObject radio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		Cursor.SetCursor (defaultCursor,Vector2.zero,CursorMode.Auto);
		radio.SetActive (true);
		background2.SetActive (true);
		background.SetActive (false);
	}
}
