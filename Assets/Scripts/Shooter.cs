using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shooter : MonoBehaviour {

	Rigidbody rB;

	public Transform origin;
	public Transform aimer;
	public Transform anchor;

	public float angleX;
	public float rotationSpeed;
	public float restriction;

	public float max;
	public float min;
	public float value = 2;
	public float incrementBy;

	bool _return = false;
	bool shoot = false;

	public float amountOfForce;
	public float incrementForce;
	public float multiple;
	public GameObject snowball;
	public Transform spawnPoint;

	public Transform theArc;

	public Vector3[] arc;
	GameObject newSpawn;
	public float speed;

	void Start () {
	
	}
	
	void Update () {
	
		Buttons ();

		origin.localEulerAngles = new Vector3(origin.localEulerAngles.x, origin.localEulerAngles.y, angleX);
		anchor.localEulerAngles = new Vector3(anchor.localEulerAngles.x, angleX, anchor.localEulerAngles.z);

		angleX = Mathf.Clamp (angleX, -restriction, restriction);

		if (_return && aimer.localPosition.y > min) {

			Vector3 temp = aimer.localPosition;

			temp.y -= incrementBy;
			amountOfForce -= incrementForce;

			aimer.localPosition = temp;
		}

		if (shoot) {

			newSpawn.transform.position = Vector3.Lerp (newSpawn.transform.position, arc [1], speed * Time.deltaTime);

			if (newSpawn.transform.position == arc [0]) {
				//newSpawn.transform.position = Vector3.Lerp (newSpawn.transform.position, arc [1], speed * Time.deltaTime);
			}

			if (newSpawn.transform.position == arc [1]) {
				shoot = false;
			}
		}
	}

	void ChangeArc(){

		Debug.Log ("spawnpoint : " + spawnPoint.position);
		Vector3 newArc = new Vector3((aimer.position.x - spawnPoint.position.x) / 2, theArc.position.y, (aimer.position.z - spawnPoint.position.z) / 2);
		Debug.Log ("target : " + aimer.position);

		theArc.position = newArc;
	}

	void Buttons(){

		//Right joystick
		if (Input.GetAxis ("CTL_LeftStickX") > 0.19f) {
			Debug.Log ("left joystick pointing right");
			angleX += Input.GetAxis("CTL_LeftStickX") * rotationSpeed;
		}

		if (Input.GetAxis ("CTL_LeftStickX") < 0) {
			Debug.Log ("left joystick pointing left");
			angleX += Input.GetAxis("CTL_LeftStickX") * rotationSpeed;
		}

		if(Input.GetButton("CTL_RightTrigger"))
		{
			HoldAim ();
			_return = false;
		}

		if(Input.GetButtonUp("CTL_RightTrigger"))
		{
			Shoot ();
			_return = true;
		}
	}

	public bool increase;

	void Aim(){

	}

	void HoldAim(){
		
		Debug.Log ("Aiming");

		ChangeArc ();

		Vector3 temp = aimer.localPosition;

		if (temp.y >= max) {
			increase = false;
		} else if (temp.y <= min) {
			increase = true;
		}

		if (increase) {
			
			temp.y += incrementBy;
			amountOfForce += incrementForce;
		} else {
			temp.y -= incrementBy;
			amountOfForce -= incrementForce;

		}

		aimer.localPosition = temp;
	}

	void Shoot(){

		newSpawn = (GameObject)Instantiate (snowball, spawnPoint.position, Quaternion.identity) as GameObject;
		//newSpawn.transform.parent = spawnPoint.transform;
		//newSpawn.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
		//Rigidbody rB = newSpawn.GetComponent<Rigidbody> ();

		//rB.AddRelativeForce (spawnPoint.transform.forward * amountOfForce * multiple, ForceMode.Impulse);

		arc [0] = theArc.position;
		arc[1] = aimer.position;

		shoot = true;
	}
}
