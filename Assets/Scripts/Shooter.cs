using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	Rigidbody rB;

	void Start () {
	
	}
	
	void Update () {
	
		Buttons ();
	}

	void Buttons(){

		if(Input.GetButton("CTL_RightTrigger"))
		{
			Aim ();
		}

		if(Input.GetButtonUp("CTL_RightTrigger"))
		{
			Shoot ();
		}
	}

	void Aim(){

	}

	void Shoot(){

	}
}
