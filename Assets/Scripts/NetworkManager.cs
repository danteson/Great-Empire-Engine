using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	string registeredGameName = "GE_GreatEmpire_Test_Server";
	float refrestRequestLength = 3.0f;
	HostData[] hostData;
	public GameObject Player;
	public bool Spawned = false;
	public Texture LogoTxt;

	private void StartServer() {
		Network.InitializeServer (16, 25000, false);
		MasterServer.RegisterHost (registeredGameName, "Great Empire Test Game", "Test Implementation.");

	}

	public IEnumerator RefreshHostList() {
		Debug.Log ("Refreshing...");
		MasterServer.RequestHostList (registeredGameName);
		float timeEnd = Time.time + refrestRequestLength;

		while (Time.time < timeEnd) {
			hostData = MasterServer.PollHostList ();
			yield return new WaitForEndOfFrame();
		}

		if (hostData.Length == 0) {
			Debug.Log ("No active servers have been found.");
		} else {
			Debug.Log(hostData.Length + " server(s) found.");
		}
	}

	private void SpawnPlayer() {
		Debug.Log ("Spawning Player...");
		Network.Instantiate (Player, new Vector3 (9, 2, 2), Quaternion.identity, 0);

	}
	
	//////////////////////////////////////////
	//Call backs from client and server.
	void OnConnectedToServer() {}
	
	void OnDisconnectedFromServer(NetworkDisconnection info){}
		
	void OnFailedToConnect(NetworkConnectionError error){}

	void OnPlayerConnected(NetworkPlayer player){}

	void OnFailedToConnectToMasterServer(NetworkConnectionError info){}

	void OnNetworkInstantiate(NetworkMessageInfo info){}

	void OnServerInitialized() {
		Debug.Log ("Server has beed initialized");
		SpawnPlayer ();
	}

	void OnMasterServerEvent(MasterServerEvent masterServerEvent) {
		if (masterServerEvent == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log ("Registration Succesful!");
		}
	}

	void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log ("Player disconnected from: " + player.ipAddress + ":" + player.port);
		Network.RemoveRPCs (player);
		Network.DestroyPlayerObjects (player);
	}

	void OnApplicationQuit() {
		if (Network.isServer) {
			Network.Disconnect(200);
			MasterServer.UnregisterHost();
		}

		if (Network.isClient) {
			Network.Disconnect(200);
		}
	}
	///////////////////////////////////////////

	public void OnGUI() {
		if (Network.isServer) {
			GUILayout.Label ("Running as a server.");
		} else if (Network.isClient) {
			GUILayout.Label("Running as a client.");
		}


		if (Network.isClient && Spawned == false) {
			if (GUI.Button(new Rect(25f,25f,150f,30f),"Spawn!")) {
				SpawnPlayer();
				Spawned = true;
			}
		}

		/*if (Network.isClient || Network.isServer) {
			return;
		}*/

		if (!Network.isClient && !Network.isServer) {
			GUI.Label (new Rect (Screen.width/2-200, Screen.height/2-250, 500, 150), LogoTxt);
			if (GUI.Button(new Rect(25f,25f,150f,30f),"Start New Server")) {
				StartServer();
			}

			if (GUI.Button(new Rect(25f,65f,150f,30f),"Refresh Server List")) {
				StartCoroutine("RefreshHostList");
			}


			if (hostData != null) {
				for (int i = 0; i < hostData.Length; i++) {
					if (GUI.Button (new Rect (Screen.width / 2, 65f + (30f * i), 300f, 30f), hostData[i].gameName)) {
						Network.Connect(hostData[i]);
					}
				}
			}
		}
	}
}








