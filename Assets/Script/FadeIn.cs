using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : MonoBehaviour 
{
	[SerializeField]private float fadeInTime;
	private Image fadePanel;
	private Color currentColor = Color.black;

	void Start()
	{
		fadePanel = GetComponent<Image>();
	}

	void Update()
	{
		if(Time.timeSinceLevelLoad < fadeInTime)
		{
			float alphaChange = Time.deltaTime /fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
