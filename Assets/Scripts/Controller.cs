using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	private CharacterController character;
	public GameObject CharCamera;

	public bool FlyMode = false;

	void Start () {
		character = GetComponent<CharacterController>();
		if (!GetComponent<NetworkView>().isMine) {
			this.enabled = false;
		}
	}


	public float flySpeed;
	public float speed;
	public float jumpSpeed;
	public float gravity;
	public float riseUp;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetKeyDown("space"))
				moveDirection.y = jumpSpeed;
			}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if (Input.GetKeyDown ("1")) {
			speed=10;
			flySpeed=10;
			jumpSpeed = 10;
			gravity = 20;
			riseUp = -600;
		}

		if (Input.GetKeyDown ("2")) {
			speed=50;
			flySpeed=50;
			jumpSpeed = 50;
			gravity = 100;
			riseUp = -3000;
		}

		if (Input.GetKeyDown ("3")) {
			speed=120;
			flySpeed=120;
			jumpSpeed = 120;
			gravity = 240;
			riseUp = -7200;
		}

		if (Input.GetKeyDown ("4")) {
			speed=250;
			flySpeed=250;
			jumpSpeed = 250;
			gravity = 500;
			riseUp = -15000;
		}


#region Flying Section
	//Movement in air
		if (FlyMode == true) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= flySpeed;
		}
	//Turn fly mode on and make gravity 0
		if (Input.GetKeyDown ("r") && FlyMode == false) {
			FlyMode = true;
			gravity = 0;
	//Turn fly mode off and make default gravity
		} else if (Input.GetKeyDown ("r") && FlyMode == true) {
			FlyMode = false;
			StopCoroutine("FloatUp");
			gravity = 20;
		}
	//Start float
		if (Input.GetKeyDown ("space") && FlyMode == true) {
			Flying();
		}
	//Add height
		if (Input.GetKey ("space") && FlyMode == true) {
			gravity = riseUp;
		}
	//Stop adding height
		if (Input.GetKeyUp ("space") && FlyMode == true) {
			StartCoroutine (StopFloat (0.5f));
			gravity = 0;
		}
	}

	void Flying() {
		StartCoroutine (FloatUp (0.0f));
	}


	IEnumerator FloatUp (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		if (FlyMode)
		gravity = -150;
		StartCoroutine (StopFloat (0.5f));
	}

	IEnumerator StopFloat (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		if (FlyMode)
		gravity = 50;
		StartCoroutine (Float (1.5f));
	}

	IEnumerator Float (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		if (FlyMode)
		gravity = 10;
	}
#endregion
	void ZoomBackIn() {
		Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,60,2f * Time.deltaTime);
	}
}
