using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {
	private GameObject destroyPoint;
	public string destroyPointName;
	// Use this for initialization
	void Start () {

		destroyPoint = GameObject.FindGameObjectWithTag (destroyPointName);
		//destroyPoint = GameObject.FindGameObjectWithTag (destroyPointName);
	}
	
	// Update is called once per frame
	void Update () {

		if (destroyPoint == null) {
			return;
		}
        else if(destroyPointName == "Cam3DestroyPoint")
        {
            if (transform.position.x < destroyPoint.transform.position.x)
            {

				gameObject.transform.rotation =  Quaternion.Euler(0.0f, 0.0f, 0.0f);
                gameObject.GetComponent<Jellyfish>().shockOff();
                gameObject.SetActive(false);

            }
        }
        else if (transform.position.x < destroyPoint.transform.position.x)
        {

			gameObject.SetActive(false);

        }

    }
}
