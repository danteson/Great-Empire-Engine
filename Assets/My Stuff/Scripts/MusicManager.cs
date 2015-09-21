using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public GameObject PlayerCamera;

	public AudioClip song1;
	public AudioClip song2;

	public int GMPanelCount = 0;



	void Update () {
		if (Input.GetKeyDown ("escape")) {
			GMPanelCount += 1;
		}

		if (GMPanelCount == 2) {
			GMPanelCount = 0;
		}
	}

	public string password = "";

	void OnGUI () {
		//podfix height 4tob s gm panel syncilsja
		if (GMPanelCount == 1) {
			password = GUI.PasswordField (new Rect (Screen.width / 2.5f, Screen.height / 2, 200, 20), password, "*" [0], 20);
			if (Event.current.keyCode == KeyCode.Return) {
				if (password == "song1") {  //Sjuda piwew nazvanije pesni zamesto song1
					GetComponent<NetworkView>().RPC("SongOne", RPCMode.AllBuffered);
				}

				if (password == "song2") {  //Sjuda piwew nazvanije pesni zamesto song2
					GetComponent<NetworkView>().RPC("SongTwo", RPCMode.AllBuffered);
				}
			}
		}
	}

	//sjuda functions 4tob vklju4atj muz]ku
	#region ALL RPC
	[RPC]
	void SongOne () {
		PlayerCamera.GetComponent<AudioSource>().clip = song1;
		PlayerCamera.GetComponent<AudioSource>().Play ();
	}

	[RPC]
	void SongTwo () {
		PlayerCamera.GetComponent<AudioSource>().clip = song2;
		PlayerCamera.GetComponent<AudioSource>().Play ();
	}
	#endregion
}
