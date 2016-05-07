using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PooledManager : MonoBehaviour {

	public bool poolOnStart;
	public Transform pooledList;
	PooledObject[] pooledListObjects;
	public List<PooledObject> possiblePooledObjects;
	public List<GameObject> currentlyPooledObjects;
	public List<GameObject> shownPooledObjects;
	public PooledObject currentObject;

	public GameObject poolHolder;
	
	public int startDist = 2;
	public int poolLength;
	public int maxPool;
	int randomRange;
	int index;
	public int count;

	GameObject lastPool;

	[HideInInspector]
	public bool spawnCollectible;

	void Start () {
	
		if (poolOnStart){
			InitializePool();
		}

		poolLength = poolLength + 1;
		maxPool = maxPool + 1;
		count = poolLength - 1;
	}

	void InitializePool(){

		pooledListObjects = pooledList.gameObject.GetComponentsInChildren<PooledObject>();
		pooledList.gameObject.SetActive(false);

		for (int i = 0; i < pooledListObjects.Length; i++){
			possiblePooledObjects.Add(new PooledObject());
			possiblePooledObjects[i] = pooledListObjects[i];
		}

		pooledListObjects = null;

		CreatePool();
	}

	void CreatePool(){

		randomRange = possiblePooledObjects.Count;

		Vector3 spawnSocket = new Vector3();

		for (int i = 0; i < maxPool; i++){

			index = Random.Range(0, randomRange);

			if (currentlyPooledObjects.Count < 1){
				spawnSocket = poolHolder.transform.position;
			}else{
				spawnSocket = currentObject.GetComponent<PooledObject>().chunkRequirments.spawnSocket.transform.position;
			}

			GameObject nextPool = (GameObject)Instantiate(possiblePooledObjects[index].gameObject, spawnSocket, Quaternion.identity) as GameObject;
			nextPool.transform.parent = poolHolder.transform;
			nextPool.name = "Pool (" + i + ")";
			currentlyPooledObjects.Add(nextPool);
			
			currentObject = nextPool.GetComponent<PooledObject>();

			if (i < poolLength){
				currentObject.gameObject.SetActive(true);
			}else{
				currentObject.gameObject.SetActive(false);
			}
		}
	}

	bool spawned = false;

	public void ShowNext(){

		GameObject current = currentlyPooledObjects[0];
		current.SetActive(false);
		StartCoroutine(SetPosition(current, currentObject));
		currentlyPooledObjects[count].SetActive(true);
		
		currentlyPooledObjects.Remove(current);
		currentlyPooledObjects.Add(current);
		
		if (count == maxPool - 1){
			count = 0;
		}
	}

	IEnumerator SetPosition(GameObject setThis, PooledObject current){
		//Debug.Log("count : " + currentlyPooledObjects.Count);
		yield return new WaitForSeconds(0.1f);
		setThis.transform.position = current.chunkRequirments.spawnSocket.transform.position;
		currentObject = currentlyPooledObjects[currentlyPooledObjects.Count - 1].GetComponent<PooledObject>();
	}
}