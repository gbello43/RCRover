using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
	// public GameObject thePlatform;      //makes the platform
	public Transform generationPoint;   //where the platforms will be created

	private float platformWidth;    //how big the platform is

	public int distanceBetween;
	public NewBehaviourScript thePlayer;

	// public GameObject[] thePlatforms;
	private int platformSelector;

	private float[] platformWidths;
	public ObjectPooler[] theObjectPools;

	public float groundLevel;
	private bool missingGround = false;


	// Use this for initialization
	void Start () {

		platformWidths = new float[theObjectPools.Length];

		for(int i = 0; i < theObjectPools.Length; i++)
		{

			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<Collider2D>().transform.localScale.x;   //gest size of the collider<box,edge,polygon2D>
		}

	}

	// Update is called once per frame
	void Update () {


		if (transform.position.x < generationPoint.position.x)
		{
			if(missingGround == true){
				platformSelector = Random.Range(0, theObjectPools.Length);

				GameObject newPlatform1 = theObjectPools[platformSelector].GetPooledObject();    //grabs a platform that is not active

				//newPlatform1.transform.position =  new Vector3(generationPoint.transform.position.x + (platformWidths[platformSelector/2]),groundLevel, generationPoint.transform.position.z);


				transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, groundLevel, transform.position.z);

				//create platform

				newPlatform1.transform.position = transform.position;
				newPlatform1.SetActive(false);
				//newPlatform1.transform.rotation = transform.rotation;

				transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, groundLevel, transform.position.z);
			}
			else{
				//distanceBetween = Random.Range(distanceBetween);

				platformSelector = Random.Range(0, theObjectPools.Length);

				GameObject newPlatform1 = theObjectPools[platformSelector].GetPooledObject();    //grabs a platform that is not active
			
				//newPlatform1.transform.position =  new Vector3(generationPoint.transform.position.x + (platformWidths[platformSelector/2]),groundLevel, generationPoint.transform.position.z);
					

				transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, groundLevel, transform.position.z);

				//create platform

				newPlatform1.transform.position = transform.position;
				newPlatform1.SetActive(true);
				//newPlatform1.transform.rotation = transform.rotation;

				transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, groundLevel, transform.position.z);

				int num = Random.Range(0,20);

				if(num == 15){
					missingGround = true;
					StartCoroutine("waitStart");

				}
			}
		}
	}

	IEnumerator waitStart()
	{
		float seconds = Random.Range(10f, 30f);
		Debug.Log("seconds: " + seconds);
		yield return new WaitForSeconds (seconds);
		missingGround = false;

	}
}
