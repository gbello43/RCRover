using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour {
	int level;
	public GameObject explosion;

    // Use this for initialization
	void Start () {

		//explosion.GetComponent<ParticleSystem> ().emission.enabled = false;
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		        
	}

	public void explode(){

		Instantiate (explosion, transform.position, transform.rotation);

	}


}
