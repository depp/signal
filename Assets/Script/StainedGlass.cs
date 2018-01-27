using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainedGlass : MonoBehaviour {
	public ColorSet colors;
	int colorIndex;
	SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown() {
		var colorArray = colors.colors;
		colorIndex++;
		if (colorIndex >= colorArray.Length) {
			colorIndex = 0;
		} else if (colorIndex < 0) {
			colorIndex = colorArray.Length - 1;
		}
		sprite.color = colorArray[colorIndex];
	}
}
