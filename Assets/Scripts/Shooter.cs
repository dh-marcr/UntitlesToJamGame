using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shooter : MonoBehaviour {

	Rigidbody rB;

	public Transform origin;

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
