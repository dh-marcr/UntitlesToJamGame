using UnityEngine;
using System.Collections;

public class MovementControls : MonoBehaviour 
{
	// These are used to modify the player movement speed, and rotation speed.

	float angleX = 0;
	float angleY = 0;

	public float turnAngle;

	public float movementSpeed = 2;

	public Transform thisFollows;

	void Update()
	{
		Movement();
		UserInputs();

		thisFollows.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
	}    

	void Movement()
	{
		// This line is for vertical movement, right now its on the Z AXIS.
		//transform.Translate(0,0,Input.GetAxis("Vertical") * Time.deltaTime * PlayerMovementSpeed);

		// This line is for horizontal movement, right now its on the X AXIS. When combined with vertical movement it can be used for Strafing.
		//transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed,0,0);

		//angleY += Input.GetAxis("CTL_RightStickY") * movementSpeed;

		transform.localEulerAngles = new Vector3(angleY, angleX, 0);

		angleX = Mathf.Clamp (angleX, -turnAngle, turnAngle);
	}

	void UserInputs()
	{

		//Left joystick

		if (Input.GetAxis ("CTL_LeftStickY") > 0.19f) {
			Debug.Log ("left joystick pointing down");
		}

		if (Input.GetAxis ("CTL_LeftStickY") < 0) {
			Debug.Log ("left joystick pointing up");
		}

		//Right joystick
		if (Input.GetAxis ("CTL_RightStickX") > 0.19f) {
			Debug.Log ("right joystick pointing right");
			angleX += Input.GetAxis("CTL_RightStickX") * movementSpeed;
		}

		if (Input.GetAxis ("CTL_RightStickX") < 0) {
			Debug.Log ("right joystick pointing left");
			angleX += Input.GetAxis("CTL_RightStickX") * movementSpeed;
		}

		if (Input.GetAxis ("CTL_RightStickY") > 0.19f) {
			Debug.Log ("right joystick pointing down");
		}

		if (Input.GetAxis ("CTL_RightStickY") < 0) {
			Debug.Log ("right joystick pointing up");
		}

		// A Button is read from Input Positive Button "joystick button 0"
		if(Input.GetButtonDown ("CTL_AButton"))
		{
			Debug.Log("A Button!");
		}

		// B Button is read from Input Positive Button "joystick button 1"
		if(Input.GetButtonDown ("CTL_BButton"))
		{
			Debug.Log("B Button!");
		}

		// X Button is read from Input Positive Button "joystick button 2"
		if(Input.GetButtonDown ("CTL_XButton"))
		{
			Debug.Log("X Button!");
		}

		// Y Button is read from Input Positive Button "joystick button 3"
		if(Input.GetButtonDown ("CTL_YButton"))
		{
			Debug.Log("Y Button!");
		}

		// Left Bumper is read from Input Positive Button "joystick button 4"
		if(Input.GetButtonDown ("CTL_LeftBumper"))
		{
			Debug.Log("Left Bumper!");
		}

		// Right Bumper is read from Input Positive Button "joystick button 5"
		if(Input.GetButtonDown ("CTL_RightBumper"))
		{
			Debug.Log("Right Bumper!");
		}

		// Back Button is read from Input Positive Button "joystick button 6"
		if(Input.GetButtonDown ("CTL_BackButton"))
		{
			Debug.Log("Back Button!");
		}

		// Start Button is read from Input Positive Button "joystick button 7"
		if(Input.GetButtonDown ("CTL_StartButton"))
		{
			Debug.Log("Start Button!");
		}

		// Left Thumbstick Button is read from Input Positive Button "joystick button 8"
		if(Input.GetButtonDown ("CTL_LeftThumbstickButton"))
		{
			Debug.Log("Left Thumbstick Button!");
		}

		// Right Thumbstick Button is read from Input Positive Button "joystick button 9"
		if(Input.GetButtonDown ("CTL_RightThumbstickButton"))
		{
			Debug.Log("Right Thumbstick Button!");
		}


		// Right Trigger is activated when pressure is under 0, or the dead zone.
		if(Input.GetButtonDown("CTL_LeftTrigger"))
		{
			Debug.Log("Left Trigger!");
		}

		// The D-PAD is read from the 6th(Horizontal) and 7th(Vertical) Joystick Axes and read from a Sensitivity rating from -1 to 1, similar to the Triggers.
		//
		// Right D-PAD Button is activated when pressure is above 0, or the dead zone.
		if(Input.GetAxis("CTL_HorizontalDPAD")> 0.001f)
		{
			Debug.Log ("Right D-PAD Button!");
		}

		// Left D-PAD Button is activated when pressure is under 0, or the dead zone.
		if(Input.GetAxis("CTL_HorizontalDPAD")< 0)
		{
			Debug.Log("Left D-PAD Button!");
		}

		// Up D-PAD Button is activated when pressure is above 0, or the dead zone.
		if(Input.GetAxis("CTL_VerticalDPAD")<0)
		{
			Debug.Log ("Up D-PAD Button!");
		}

		// Down D-PAD Button is activated when pressure is under 0, or the dead zone.
		if(Input.GetAxis("CTL_VerticalDPAD")> 0.001f)
		{
			Debug.Log("Down D-PAD Button!");
		}
	}
}
