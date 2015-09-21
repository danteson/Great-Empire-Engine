using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {


	public Texture CrosshairTxt;
	public bool CrosshairActivate = false;




	void Start () {
		if (!GetComponent<NetworkView>().isMine) {
			GetComponent<Camera>().enabled = false;
		}
	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			CrosshairActivate = true;
		} else {
			CrosshairActivate = false;
		}


	}

	void OnGUI () {
		if (CrosshairActivate == true) {
			GUI.backgroundColor = new Color (0, 0, 0, 0);
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-50, 200, 60), CrosshairTxt);
		}
	}
}