using UnityEngine;
using System.Collections;

public class PlayerForce : MonoBehaviour {

	public Transform forcePoint;
	public float forceVal;
	public float slowForce;
	public float actualForce;

	public float maxSpeed;
	public float minSpeed;

	Rigidbody rB;

	void Start () {
	
		if (rB == null) {
			rB = GetComponent<Rigidbody> ();
		}

		actualForce = forceVal;
	}
	
	void Update () {
			
		rB.AddForce (transform.forward * actualForce);

		Debug.Log ("velocity : " + rB.velocity);

		if (rB.velocity.z >= maxSpeed) {

			actualForce = slowForce;
		} else if (rB.velocity.z < minSpeed){
			actualForce = forceVal;
		}
	}
}
