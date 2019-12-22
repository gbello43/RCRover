using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyText : MonoBehaviour {
	float destroyTime = 2f;
	//public Vector3 offset = new Vector3 (0.0f,3f,0.0f);
	// Use this for initialization
	void Start () {
		//transform.localPosition += offset;
		Destroy (gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
