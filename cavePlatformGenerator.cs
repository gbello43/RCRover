using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavePlatformGenerator : MonoBehaviour
{
	// public GameObject thePlatform;      //makes the platform
	public Transform generationPoint;   //where the platforms will be created
	private float distanceBetween;       //distance between platforms

	private float platformWidth;    //how big the platform is

	public int distanceBetweenMin;
	public int distanceBetweenMax;
	public NewBehaviourScript thePlayer;

	// public GameObject[] thePlatforms;
	private int platformSelector;
	private int platformSelector2;
	private int platformSelector3;

	private float[] platformWidths;
	public ObjectPooler[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	public Transform minHeightPoint;
	private float maxHeight;
	public float maxHeightChange;


	private float heightChange;

	public CrystalGenerator theCrystalGenerator;
	public float randomCrystalThreshold;   //create a crystal or not

	public PortalGenerator portalGenerator;
	public float randomPortalThreshold;

	public OrbGenerator theOrbGenerator;


	// Use this for initialization
	void Start () {

		platformWidths = new float[theObjectPools.Length];

		for(int i = 0; i < theObjectPools.Length; i++)
		{

			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<Collider2D>().transform.localScale.x;   //gest size of the collider<box,edge,polygon2D>
			Debug.Log("Platform: " + i + " platformWidth: " + platformWidths[i]);
		}

		//minHeight = transform.position.y;

		maxHeight = maxHeightPoint.position.y;        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; //gets the size of the platform
		minHeight = minHeightPoint.position.y;


		//theCrystalGenerator = FindObjectOfType<CrystalGenerator>();

		//portalGenerator = FindObjectOfType<PortalGenerator> ();

		//theOrbGenerator = FindObjectOfType<OrbGenerator>();
	}

	// Update is called once per frame
	void Update () {


		if (transform.position.x < generationPoint.position.x)
		{
			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range(0, theObjectPools.Length);
			platformSelector2 = Random.Range(0, theObjectPools.Length);
			platformSelector3 = Random.Range(0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);    //the current height position of the platform
			//max and min height platforms can go
			if (heightChange > maxHeight)
			{

				heightChange = maxHeight;

			}
			else if (heightChange < minHeight)
			{

				heightChange = minHeight;
			}


			GameObject newPlatform1 = theObjectPools[platformSelector].GetPooledObject();    //grabs a platform that is not active
			GameObject newPlatform2 = theObjectPools[platformSelector2].GetPooledObject();
			GameObject newPlatform3 = theObjectPools[platformSelector3].GetPooledObject();




			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

			//create platform

			newPlatform1.transform.position = transform.position;
			newPlatform1.transform.rotation = transform.rotation;
			newPlatform1.SetActive (true);
			newPlatform2.transform.position = new Vector3 (transform.position.x + (platformWidths [platformSelector2] / 2) + distanceBetween, heightChange -15f, transform.position.z); //(x, tranform.position.y -15f, z)
			newPlatform2.SetActive (true);
			newPlatform3.transform.position = new Vector3 (transform.position.x + (platformWidths [platformSelector3] / 2) + distanceBetween, heightChange + 15f, transform.position.z);
			newPlatform3.SetActive (true);


			float num = Random.Range (0f, 100f);
			//generate orbs
			if (num <= 30)
			{
				float size = (platformWidths[platformSelector]/2) * 13;

				float orbStart = (platformWidths[platformSelector]/2) * 14;

				Vector2 newPos = new Vector2(newPlatform1.transform.position.x - orbStart, newPlatform1.transform.position.y + 10f);	//new vector2 with -size of object


				if(platformSelector == 2)	//orbs with crystal - 10 orbs for bridge
				{
					Debug.Log("2");
					theOrbGenerator.SpawnOrbs(newPos, 10);//new Vector2(newPlatform1.transform.position.x - size, newPlatform1.transform.position.y + 3f), 10);

					theCrystalGenerator.SpawnCrystal(new Vector2(newPlatform1.transform.position.x + size, newPlatform1.transform.position.y + 3f));

				}
				else if(platformSelector == 1)
				{
					Debug.Log("1");
					theOrbGenerator.SpawnOrbs(newPos, 5);//new Vector2(newPlatform1.transform.position.x - size, newPlatform1.transform.position.y + 3f), 10);

					theCrystalGenerator.SpawnCrystal(new Vector2(newPlatform1.transform.position.x + size, newPlatform1.transform.position.y + 5f));

				}
				Debug.Log("0");
				//theOrbGenerator.SpawnOrbs(new Vector2(newPlatform1.transform.position.x, newPlatform1.transform.position.y + 4f));

				//create crystal
				//theCrystalGenerator.SpawnCrystal(new Vector2(newPlatform1.transform.position.x, newPlatform1.transform.position.y + 2f));

			}//spawn protal

			else if ((num >= 31 && num <=45) && (thePlayer.transform.position.x > 500))
			{
				portalGenerator.SpawnPortal(new Vector3(newPlatform2.transform.position.x, newPlatform2.transform.position.y + 4f, newPlatform2.transform.position.z));

			}
			else if (num >= 46 && (newPlatform3 == true)) {

				float size = (platformWidths[platformSelector3]/2) * 10;

				//float orbStart = (platformWidths[platformSelector3]/2) * 14;

				Vector2 newPos = new Vector2(newPlatform3.transform.position.x - size, newPlatform3.transform.position.y + 4f);	//new vector2 with -size of object

				//Debug.Log("Platform3: " + platformSelector3 + " at: " + newPos); 

				if(platformSelector3 == 2)	//orbs with crystal - 10 orbs for bridge
				{

					theOrbGenerator.SpawnOrbs(newPos, 10);//new Vector2(newPlatform1.transform.position.x - size, newPlatform1.transform.position.y + 3f), 10);

				}
				else if(platformSelector3 == 1)
				{
					theOrbGenerator.SpawnOrbs(newPos, 7);//new Vector2(newPlatform1.transform.position.x - size, newPlatform1.transform.position.y + 3f), 10);

				}            
			}

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
		}
	}
}
