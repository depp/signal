using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamineObjectButton : MonoBehaviour {

	Button theButton;
	public GameObject Examined;
	public Transform activeMarker;
	public Transform inactiveMarker;
	public Vector3 activeDimensions;
	public float speed;
	bool active;

	// Use this for initialization
	void Start () {

		theButton = gameObject.GetComponent<Button> ();
		active = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		theButton.onClick.AddListener (ClickTask);

		if (active == true) {

			Examined.transform.localScale = Vector3.Slerp (Examined.transform.localScale, activeDimensions, Time.deltaTime * speed);
			Examined.transform.position = Vector3.Slerp (Examined.transform.position, activeMarker.position, Time.deltaTime * speed);
		
		} else {

			Examined.transform.localScale = Vector3.Slerp (Examined.transform.localScale, Vector3.zero, Time.deltaTime * speed);
			Examined.transform.position = Vector3.Slerp (Examined.transform.position, inactiveMarker.position, Time.deltaTime * speed);
		}

		if (active == true) {
	

			if (Input.GetMouseButtonDown(0)) {

				Ray ray;
				RaycastHit bigHit;

				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out bigHit)) {
					if (bigHit.transform.gameObject == gameObject)
						return;
				}

				active = false;
			}
		}
	}

	void ClickTask () {

		active = true;
	}
}
