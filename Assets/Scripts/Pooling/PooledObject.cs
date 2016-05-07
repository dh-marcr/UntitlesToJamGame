using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//[ExecuteInEditMode]
public class PooledObject : MonoBehaviour{

	public ChunkRequirments chunkRequirments;
	//public ChunkDetails chunkDetails;

	void Start () {
	
		//SetupGaizers ();
		//SetupIceCrystals ();
		//SetupImmunity ();
	}
	/*
	void OnEnable(){

		if (chunkRequirments.resetOnRespawn) {

			SetupGaizers ();
			SetupIceCrystals ();
			SetupImmunity ();
		}
	}*/

	void Update () {
	
	}

	public void BuildChunk(){

		Debug.Log ("Building chunk");

		objectsList = new List<Transform> ();

		Vector3 tempTrigger = chunkRequirments.trigger.transform.localPosition;
		Vector3 tempSpawnSocket = chunkRequirments.spawnSocket.transform.localPosition;

		chunkRequirments.spawnSocket.transform.parent = null;
		chunkRequirments.trigger.transform.parent = null;

		tempTrigger = new Vector3 (0, chunkRequirments.trigger.transform.localScale.y / 2, chunkRequirments.bounds.bounds.center.z);
		tempSpawnSocket = new Vector3 (0, 0, chunkRequirments.bounds.bounds.size.z / 2);
		chunkRequirments.collectables.transform.localPosition = Vector3.zero;

		chunkRequirments.trigger.transform.localPosition = tempTrigger;
		chunkRequirments.spawnSocket.transform.localPosition = tempSpawnSocket;

		chunkRequirments.spawnSocket.transform.parent = transform;
		chunkRequirments.trigger.transform.parent = transform;

		if (!chunkRequirments.resetOnRespawn) {

		//	ClearObjects ();
			//SetupGaizers ();
			//SetupIceCrystals ();
			//SetupImmunity ();
		}
	}
	/*
	void SetupGaizers(){

		for (int i = 0; i < chunkDetails.numOfGaizers; i++) {

			int index = Random.Range (0, chunkRequirments.gaizerPoints.Length);

			if (!chunkRequirments.usedGaizerPoints.Contains (chunkRequirments.gaizerPoints [index])) {
				GameObject newGaizer = (GameObject)Instantiate (chunkRequirments.prefabs.gaizer, chunkRequirments.spawnedObjects.transform.position, Quaternion.identity) as GameObject;

				objectsList.Add (newGaizer.transform);
				newGaizer.transform.parent = chunkRequirments.spawnedObjects.transform;

				newGaizer.transform.localPosition = chunkRequirments.gaizerPoints [index].localPosition;

				chunkRequirments.usedGaizerPoints.Add (chunkRequirments.gaizerPoints [index]);
			} else {
				i--;
			}
		}
	}*/

	void SetupImmunity(){

	}

	void SetupIceCrystals(){

	}

	public Transform[] objects;
	public List<Transform> objectsList;

	public void ClearObjects(){

		//chunkRequirments.usedGaizerPoints.Clear ();

		//objects = chunkRequirments.spawnedObjects.GetComponentsInChildren<Transform> ();

		//objectsList = new List<Transform> ();

		//objectsList = objects.ToList ();

		//objectsList.Remove (chunkRequirments.spawnedObjects.transform);

		//objects = null;
		//objects = objectsList.ToArray ();

		for (int i = 0; i < objectsList.Count; i++) {
			Debug.Log ("List : " + objectsList.Count + " i : " + i);
			DestroyImmediate (objectsList [i].gameObject);
		}

		//objects = null;
		objectsList.Clear ();
	}
}

[System.Serializable]
public class ChunkRequirments{

	public bool resetOnRespawn = false;

	public Transform spawnSocket;
	public GameObject trigger;
	//public GameObject container;
	public GameObject collectables;
	public GameObject spawnedObjects;
	public Collider bounds;
	/*
	//[Header("SpawnInfo")]
	//public Transform[] gaizerPoints;
	//[HideInInspector]
	public List<Transform> usedGaizerPoints;
	public Transform[] immnunityPoints;
	*/
	public Prefabs prefabs;
}

[System.Serializable]
public class Prefabs{
	public GameObject gaizer;
	public GameObject immunity;
	public GameObject slipStream;
	public GameObject fallingIceCrystals;
}
/*
[System.Serializable]
public class ChunkDetails{

	public int numOfGaizers;
	[Range(0,10)]
	public int chanceOfImmunity;

}*/
