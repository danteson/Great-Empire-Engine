using UnityEngine;
using System.Collections;

public class PanelOfGreatness : MonoBehaviour {


	public GameObject panel;
	public GameObject music;

	public int menuOpen = 0;


	void Update () {
		if (menuOpen == 1) {
			panel.SetActive (true);
			music.SetActive (false);
		} else {
			panel.SetActive (false);
		}

		if (menuOpen == 2) {
			menuOpen = 0;
		}

	}

	public void togglePanel () {
		menuOpen += 1;
	}

	public void openMusic () {
		music.SetActive (true);
		menuOpen = 0;
	}
}
