using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayertrackCam : MonoBehaviour {

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

    private bool moved = false;

	// Use this for initialization
	void Start () {
		startPoint = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");

		lastPosition = player.transform.position;

        //GetComponent<Rigidbody>().velocity = new Vector2(2, 0);    // Vector2(x,y)start moving camera forward
    }
	
	// Update is called once per frame
	void Update () {

        //zoom camera out 
		if (FindObjectOfType<PauseMenu> ().isPaused == true) {
			return;
		}
		else 
		{

            moved = true; 

			distanceToMove = player.transform.position.x - lastPosition.x;

			transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z); 

			lastPosition = player.transform.position;

		}
       /* else if (player.transform.position.x < 750)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.005f);
        }*/
        //gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }

	public Vector3 getCurrentPos(){
	
		return transform.position;
	}
    private void LateUpdate()
    {
        //clamps camera to x position and follows on y position 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(player.transform.position.y, yMin,yMax), transform.position.z);
    }
    //reset camera 
	public void resetCamera(){
        //transform.position = new Vector3(transform.position.x, transform.position.y, -30);
        if (moved == true)
        {
            transform.position = startPoint;
        }
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
