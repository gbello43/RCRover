using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour {
	
	public GameObject[] cameras;
	Vector3[] camStartPoints;
	private NewBehaviourScript thePlayer;
	private PortalGenerator portalGenerator;

	int activeCam;


	// Use this for initialization
	void Start () {


		thePlayer = FindObjectOfType<NewBehaviourScript> ();
			
		activeCam = 0;

		camStartPoints = new Vector3[cameras.Length];

		for (int i = 0; i < cameras.Length; i++) 
		{
			camStartPoints [i] = cameras [i].transform.position;

		}

		portalGenerator = FindObjectOfType<PortalGenerator> ();
	}
	
	// Update is called once per frame
	public void switchCamera(int next)
	{
		
		cameras [activeCam].SetActive (false);

		cameras [next].SetActive (true);
		//cameras [activeCam].SetActive (false);
		activeCam = next;


		Vector3 moveTo = cameras[activeCam].GetComponent<PlayertrackCam>().getCurrentPos();
		//Instantiate Exit Portal
		portalGenerator.spawnExitPortal(new Vector3(moveTo.x - 10f, moveTo.y, 0));

		thePlayer.transform.position = new Vector3 (moveTo.x - 10f, moveTo.y, 0);

		cameras [next].GetComponent<PlayertrackCam> ().lastPosReset ();

	}


	public int getActive(){
		
		return activeCam;
	}

	public void resetCameras()
	{
		cameras [activeCam].SetActive (false);
		cameras [0].SetActive (true);

		//start from 1 because mainMenu camera doesn't move
		for (int i = 1; i < cameras.Length; i++) {

            if (i == 3)
            {
                cameras[i].transform.position = camStartPoints[i];
                //cameras[i].GetComponent<TrackCamHoriz>().resetCamera();
            }
            else
            {
                cameras[i].GetComponent<PlayertrackCam>().resetCamera();
            }
		}
		cameras [1].GetComponent<PlayertrackCam> ().lastPosReset ();
		activeCam = 0;

	
	}


}
