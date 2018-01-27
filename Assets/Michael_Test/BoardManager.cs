using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	public BoardSlot[] board;
	public bool letterIsPlaced = false;
	public SpriteRenderer letter;

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < board.Length-1; i ++){
			if (board [i].containsLetter) {
				letterIsPlaced = true;
				break;
			}
		}

		if (letterIsPlaced) {
			letter.enabled = false;
		} else {
			letter.enabled = true;
		}
	}

	public void ClearBoard(){
		letterIsPlaced = false;
		for (int i = 0; i < board.Length - 1; i++) {
			board [i].containsLetter = false;
		}
	}
}
