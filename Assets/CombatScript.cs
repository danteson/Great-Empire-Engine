using UnityEngine;
using System.Collections;

public class CombatScript : MonoBehaviour {
	public float Hit;
	public GameObject MyCamera;
	public Vector3 OffsetVector = new Vector3(0,0,0);


	void Update() {
		transform.Rotate(0,0*Time.deltaTime,Hit);

		if (Hit==0)
		{
			transform.eulerAngles = new Vector3 (-90,MyCamera.transform.eulerAngles.y,0);
		}
	}
}