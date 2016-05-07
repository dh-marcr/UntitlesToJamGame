using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

	public float aliveFor;

	void Start () {
	
	}
	
	void Update () {
	
		aliveFor -= Time.deltaTime;

		if (aliveFor <= 0){
			Destroy (gameObject);
		}
	}
}
