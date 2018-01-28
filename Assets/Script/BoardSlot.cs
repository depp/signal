using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlot : MonoBehaviour {
	public BoardManager manager;
	public bool containsLetter = false;

	public Sprite empty;
	public Sprite full;

	SpriteRenderer sprite;

	void Start(){
		sprite = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (containsLetter) {
			sprite.sprite = full;
		} else {
			sprite.sprite = empty;
		}
	}

	void OnMouseDown(){
		if (containsLetter == false){
			manager.ClearBoard ();
			containsLetter = true;
		}else{
			manager.ClearBoard ();
			manager.letterIsPlaced = false;
		}
	}
}
