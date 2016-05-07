using UnityEngine;
using System.Collections;

public class PoolMovement : MonoBehaviour {

	public Transform pool;
	public bool invert;

	public bool begin;
	bool hasYet = false;

	[Range(0.1f, 200)]
	public float movementSpeed;

	float startTime;
	float currentTime;

	public float startDist;
	public int multiple;

	void Start () {

		begin = false;

		Vector3 pos = transform.localPosition;

		pos.z = invert ? -startDist * multiple : startDist * multiple;

		transform.localPosition = pos;

		//events
	}

	void Init(){

		begin = true;
	}

	void Update () {
	
		if (begin){
			if (!hasYet){
				currentTime = Time.time;
				hasYet = !hasYet;
			}

			float absoluteMovement = Time.deltaTime * movementSpeed;

			Vector3 poolVal = pool.localPosition;

			poolVal.z += invert ? -absoluteMovement : absoluteMovement;

			pool.localPosition = poolVal;
		}
	}
}
