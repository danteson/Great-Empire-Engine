using UnityEngine;
using System.Collections;

public class CameraGUI : MonoBehaviour {

	private bool GUItrue = true;
	public Texture LogoTxt;

	void OnGUI () {
		if (GUItrue) {
			GUI.Label (new Rect (Screen.width/2-200, Screen.height/2-250, 500, 150), LogoTxt);
		}
	}
}
