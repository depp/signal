using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StainedGlass : MonoBehaviour, IPointerDownHandler {
	public ColorSet colors;
	public int colorIndex;
	public int position;
	SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
		colorIndex = GameManager.glassState [position];
	}

	void Update(){
		var colorArray = colors.colors;
		sprite.color = colorArray [colorIndex];
		GameManager.glassState [position] = colorIndex;
	}

	public void OnPointerDown(PointerEventData data) {
		if (GameManager.glassPuzzleDone == false) {
			var colorArray = colors.colors;
			colorIndex++;
			if (colorIndex >= colorArray.Length) {
				colorIndex = 0;
			} else if (colorIndex < 0) {
				colorIndex = colorArray.Length - 1;
			}
			sprite.color = colorArray [colorIndex];
		}
	}
}
