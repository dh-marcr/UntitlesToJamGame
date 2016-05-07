using UnityEngine;
using System.Collections;

public class TriggerNextPool : MonoBehaviour {

	PooledManager manager;

	void Start () {
	
		if (manager == null){
			manager = FindObjectOfType<PooledManager>();
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player"){

			manager.ShowNext();
		}
	}
}
