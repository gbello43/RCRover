using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeterControl : MonoBehaviour {
	public static float maxHitPoints;
	public static float currentHitPoints;
    public Image meter;
    private cameraManager cm;

	private PauseMenu Pause;
    int level;

	// Use this for initialization
	void Start () {
        cm = FindObjectOfType<cameraManager > ();
        maxHitPoints = GetComponent<Transform> ().localScale.x;
		currentHitPoints = GetComponent<Transform> ().localScale.x;
		Pause = FindObjectOfType<PauseMenu> ();
	}

	// Update is called once per frame
	void Update () {

        level = cm.getActive();
		//Update the Meter
		GetComponent<Transform>().localScale = new Vector3 (currentHitPoints, transform.localScale.y, transform.localScale.z);

    }
	//decreses the meter hit points
	public void DecreaseGauge(float percentage){

        level = cm.getActive();
        
        if (currentHitPoints < 0)
        {
            //FindObjectOfType<GameManager>().DeathScreen();
        }
        else if(level == 1 || level == 2)
        {
            currentHitPoints -= percentage / 2f;
        }
        else if ((currentHitPoints > 0) && (Pause.isPaused == false))
        {

            currentHitPoints -= percentage;

        }
	}
	//INcreases the meter hit points
	public void IncreaseGauge (float percentage){


        currentHitPoints += percentage;

		if (currentHitPoints >= maxHitPoints) {
			currentHitPoints = maxHitPoints;
		} 
	}

	public void resetGauge(){
		currentHitPoints = maxHitPoints;

	
	}
}
