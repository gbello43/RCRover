using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPortal : MonoBehaviour
{
	GameManager gm;
	PauseMenu pm;
	public cameraMove movingPlatform;
	public cameraMove mainCam;

	// Update is called once per frame
	void Start()
	{
		gm = FindObjectOfType<GameManager> ();
		pm = FindObjectOfType<PauseMenu>();
		//teleportTo = reciever.transform.position;

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//int next = PlayerPrefs.GetInt ("nextLevel");

		if (other.name == "Player") 
		{
			gm.switchLevel ();
			pm.enablePUI();
			movingPlatform.back();
			FindObjectOfType<NewBehaviourScript>().setMoveSpeed(17.0f);
			mainCam.moveToScreen();
			//gameObject.GetComponent<PauseMenu>().enablePUI();
		}
		//Destroy (gameObject, 1f);

	}

}
