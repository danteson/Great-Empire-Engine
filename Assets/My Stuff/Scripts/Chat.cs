using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Chat : MonoBehaviour {

	public List<string> chatHistory = new List<string>();

	public List<string> chatHistoryNames = new List<string>();

	private string currentMessage = string.Empty;
	private string currentName = string.Empty;
	public int chatHidden = 0;
	public string ShowHide = "";

	public float xcord = 0.0f;
	public float ycord = 0.0f;
	public float zcord = 0.0f;
	public float ccord = 0.0f;

	void Start () {

	}

	void Update () {
		if (chatHidden == 2) {
			chatHidden = 0;
		}

		if (chatHidden == 0) {
			ShowHide = "Hide box!";
		}

		if (chatHidden == 1) {
			ShowHide = "Show box!";
		}
	}

	private void SendMessage() {
		if (!string.IsNullOrEmpty (currentMessage.Trim ())) {
			GetComponent<NetworkView>().RPC ("ChatMessage", RPCMode.AllBuffered, new object[] { currentMessage });
			GetComponent<NetworkView>().RPC ("ChatMessageName", RPCMode.AllBuffered, new object[] { currentName });
			currentMessage = string.Empty;
		}
	}

	public Vector2 scrollPosition = Vector2.zero;

	private void Bottom() {
			GUI.SetNextControlName ("Message");
			Input.eatKeyPressOnTextFieldFocus = true;
			currentName = CharacterData.GetName ();
			currentMessage = GUI.TextArea (new Rect ( Screen.width/80, Screen.height/1.66f, 100, 20), currentMessage);
			if (Event.current.keyCode == KeyCode.Return && currentMessage != null &&
				GUI.GetNameOfFocusedControl () == "Message") {
				SendMessage ();
				//GUI.FocusControl(null);
			}
		

		if (GUI.GetNameOfFocusedControl () == "") {
			currentMessage = "";
		}
		


		//if (Event.current.keyCode == KeyCode.Return) {
		//if (Input.GetKeyDown("u")) {
			//GUI.FocusControl ("Message");
		//}
			GUILayout.BeginHorizontal ();
			GUILayout.Space (Screen.width/35);
			GUILayout.BeginVertical ();
			GUILayout.Space (Screen.height/1.55f); 
			GUI.color = Color.white;
			//for (int a = chatHistoryNames.Count - 1; a >= 0; a--) {
			for (int i = chatHistory.Count - 1, a = chatHistoryNames.Count - 1; i >= 0 && a >= 0; i--, a--) {
			GUILayout.Label (chatHistoryNames [a] + " : " + chatHistory [i], GUILayout.Width (Screen.width/3.4f));
			//}
			//}
		}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
	}


	private void Top() {
		GUILayout.Space (15);
		GUILayout.BeginHorizontal(GUILayout.Width(259));
		currentMessage = GUILayout.TextField (currentMessage);
		if (GUILayout.Button ("Send") || Input.GetKeyDown("enter")) {
			SendMessage();
		}
		GUILayout.EndHorizontal ();
		
		foreach (string c in chatHistory)
			GUILayout.Label (c);
	}

	private void OnGUI() {
		GUI.depth = 0;
		if (GUI.Button (new Rect(Screen.width/ 160, Screen.height/ 1.9f, 20, 20), "<>")) {
			chatHidden += 1;
		}
		GUI.depth = 2;
		if (chatHidden == 0) {
			GUI.Box (new Rect (Screen.width / 200, Screen.height / 1.76f,Screen.width / 2.9f,Screen.height / 3), "CHAT");
		}
		Bottom ();
	}

	[RPC]
	public void ChatMessage(string message) {
		chatHistory.Add (message);
	}

	[RPC]
	public void ChatMessageName(string message) {
		chatHistoryNames.Add (message);
	}

}
