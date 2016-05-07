using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PooledObject))]
public class PooledObjectEditor : Editor {

	public override void OnInspectorGUI(){

		DrawDefaultInspector ();

		if (GUILayout.Button ("Build Chunk")) {

			PooledObject pooled = (PooledObject)target;
			pooled.BuildChunk ();
		}
		/*
		if (GUILayout.Button ("Clear")) {

			PooledObject pooled = (PooledObject)target;
			pooled.ClearObjects ();
		}*/
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
