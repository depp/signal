﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	public BoardSlot[] board;
	public bool letterIsPlaced = false;
	public SpriteRenderer letter;

	public int letterPosition;

	void Awake(){
		if (GameManager.letterState >= 0) {
			letterPosition = GameManager.letterState;
			letterIsPlaced = true;
			board [letterPosition].containsLetter = true;
		}
	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < board.Length; i ++){
			if (board [i].containsLetter) {
				letterIsPlaced = true;
				letterPosition = i;
				break;
			}
		}

		if (letterIsPlaced) {
			letter.enabled = false;
		} else {
			letter.enabled = true;
		}

		if (letterIsPlaced) {
			GameManager.letterState = letterPosition;
		}else{
			GameManager.letterState = -1;
		}

		if (letterIsPlaced && board [8].containsLetter) {
			GameManager.letterPuzzleDone = true;
		}
	}

	public void ClearBoard(){
		letterIsPlaced = false;
		for (int i = 0; i < board.Length; i++) {
			board [i].containsLetter = false;
		}
	}
}
