using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	public GameObject splashParticle;
	public GameObject savedLevelPosition;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void portalInitiation()
	{
		Debug.Log ("Player Killed");
		Instantiate (splashParticle, player.transform.position, player.transform.rotation);
		player.SetActive(false);
		//player.transform.position = savedLevelPosition.transform.position;
	}


}
	