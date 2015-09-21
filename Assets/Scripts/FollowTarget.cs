using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform Target;
	public Transform Target2;

	public bool TargetEnemy = false;
	public bool TargetFollow = false;
	public bool Target2Follow = false;

	public int speed = 100;

	public Vector3 Distance;

	void Start () {
		//Target = GameObject.FindWithTag("Target").transform;
		//Target2 = GameObject.FindWithTag("Player").transform;
	}

	void Update () {
		if (TargetFollow == true) {
			transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * speed);
		}



		if (Target2Follow == true) {
			GetComponent<CharacterController>().enabled = false;
			transform.position = Vector3.MoveTowards(transform.position, Target2.position, Time.deltaTime * speed);
		}
		if (Target2Follow == false) {
			GetComponent<CharacterController>().enabled = true;
		}


		#region Attack Target
		if (TargetEnemy == true) {
			//Attack function
		}
		#endregion

	}

	void OnMouseOver() {
		if(Input.GetKeyDown("6")) {
			GetComponent<NetworkView>().RPC("FollowOn", RPCMode.AllBuffered);
		}

		if(Input.GetKeyDown("7")) {
			GetComponent<NetworkView>().RPC("FollowOn2", RPCMode.AllBuffered);
		}

		if(Input.GetKeyDown("0")) {
			GetComponent<NetworkView>().RPC("DestroyRPC", RPCMode.AllBuffered);
		}
		if(Input.GetKeyDown("8")) {
			GetComponent<NetworkView>().RPC("FollowOn2", RPCMode.AllBuffered);
		}
	}


	[RPC]
	void FollowOn () {
		if (!TargetFollow) {
			StartCoroutine(FollowTargetOn(0.2f));
		} else {
			StartCoroutine(FollowTargetOff(0.2f));
		}
	}

	[RPC]
	void FollowOn2 () {
		if (!Target2Follow) {
			StartCoroutine(FollowTarget2On(0.2f));
		} else {
			StartCoroutine(FollowTarget2Off(0.2f));
		}
	}

	[RPC]
	void DestroyRPC () {
		Destroy (this.gameObject);
	}

	IEnumerator FollowTargetOn (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		TargetFollow = true;
	}

	IEnumerator FollowTargetOff (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		TargetFollow = false;
	}

	IEnumerator FollowTarget2On (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Target2Follow = true;
	}

	IEnumerator FollowTarget2Off (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Target2Follow = false;
	}
}
