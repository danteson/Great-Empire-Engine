using UnityEngine;
using System.Collections;

public class ChangingCharactersOverNetwork : MonoBehaviour {

	public GameObject Dima;
	public GameObject Marcel;
	public string myStrings;

	void Start () {
		
		if (!GetComponent<NetworkView>().isMine) {
			this.enabled = false;
		}}

		public string password = "Change character";
		void OnGUI () {
		if (GetComponent<Spawner> ().gmPanel == 1) {
			password = GUI.PasswordField (new Rect (Screen.width / 2.5f, Screen.height / 3.2f, 200, 20), password, "*" [0], 20);
		
			if (Event.current.keyCode == KeyCode.Return) {

				if (password == "marcel") {
					GetComponent<NetworkView>().RPC ("MarcelActive", RPCMode.All);
				}
				if (password == "dima") {
					GetComponent<NetworkView>().RPC ("DimaActive", RPCMode.All);
				}
				if (password == "empty") {
					GetComponent<NetworkView>().RPC ("EmptyActive", RPCMode.All);
				}
				password = string.Empty;
			}
		}
	}
	
	[RPC]
	private void MarcelActive() {
		Dima.SetActive(false);
		Marcel.SetActive(true);
		}

	[RPC]
	private void EmptyActive() {
		Dima.SetActive(false);
		Marcel.SetActive(false);
	}
	
	[RPC]
	private void DimaActive() {
		Dima.SetActive(true);
		Marcel.SetActive(false);
		}
}
