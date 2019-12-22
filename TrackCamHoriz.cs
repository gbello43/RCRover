using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCamHoriz : MonoBehaviour {

	private Vector3 startPoint;

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;

	private GameObject player;

	private Vector3 lastPosition;
	private float distanceToMove;

	// Use this for initialization
	void Start () {
		startPoint = transform.position;

		player = GameObject.FindGameObjectWithTag("Player3D");

		lastPosition = player.transform.position;

		//GetComponent<Rigidbody>().velocity = new Vector2(2, 0);    // Vector2(x,y)start moving camera forward
	}

	// Update is called once per frame
	void Update () {

		distanceToMove= player.transform.position.z - lastPosition.z;

		transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + distanceToMove); 

		lastPosition = player.transform.position;

		/*
		//zoom camera out 
		if (FindObjectOfType<PauseMenu> ().isPaused == true) {
			return;
		}
		else 
		{

			distanceToMove = player.transform.position.z - lastPosition.z;

			transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + distanceToMove); 

			lastPosition = player.transform.position;

		}*/

	}

	public Vector3 getCurrentPos(){

		return transform.position;
	}
	private void LateUpdate()
	{
		//clamps camera to x position and follows on y position 
		transform.position = new Vector3( Mathf.Clamp(player.transform.position.x, xMin,xMax), transform.position.y, transform.position.z);
	}
	//reset camera 
	public void resetCamera(){
		//transform.position = new Vector3(transform.position.x, transform.position.y, -30);
		transform.position = startPoint;

	}

	public void lastPPosition()
	{
		Debug.Log ("Player last position: " + lastPosition);
	}
	public void lastPosReset()
	{

		if (player == null) {
			return;
		} else {
			lastPosition = player.transform.position;
		}
	}

}
