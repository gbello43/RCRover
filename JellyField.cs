using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyField : MonoBehaviour
{
    public ScoreManager SM;
    private GameManager GM;
    public Transform[] spawnPoints;       //vectors for projectiles

    //public ObjectPooler[] seaCrits;
    public ObjectPooler[] seaCrits;
    private PortalGenerator PG;
    public NewBehaviourScript thePlayer;

    //public GameObject astroidPrefab;
    //public GameObject[] asteroidTypes;

    public GameObject portalPrefab;

    private float timeToSpawn = 0.1f;//2f;

    private float timeBetweenWaves;// = 0.5f; 1f;

    private int level;

    //private float portalThreshold;

    private bool isActive;
    // Use this for initialization
    void Start()
    {

        GM = FindObjectOfType<GameManager>();

        SM = FindObjectOfType<ScoreManager>();

        PG = FindObjectOfType<PortalGenerator>();

        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {



        if (isActive == false)
        {

        }
        else if (Time.time >= timeToSpawn)
        {
            timeToSpawn = 0.1f;
			timeBetweenWaves = Random.Range(0.5f,1.5f);//1f;
            float index = Random.Range(0f, 200f);

            if ((index <= 15) && (thePlayer.transform.position.x >= 500))
            {
                spawnPortal();
                timeToSpawn = Time.time + timeBetweenWaves;


            }
			else if(index >=16 && index <= 140)
            {
                spawnObjects();
                timeToSpawn = Time.time + timeBetweenWaves ;
            }
			else 
			{
				spawnSingleProjectile();
				timeToSpawn = Time.time + timeBetweenWaves;
			}
        }

    }
    public void Active()
    {
        isActive = true;
    }
    public void deactivate()
    {

        isActive = false;
    }
    void spawnObjects()
    {

        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomIndex2 = Random.Range(0, spawnPoints.Length);
        int randomIndex3 = Random.Range(0, spawnPoints.Length);
        int randomIndex4 = Random.Range(0, spawnPoints.Length);


        for (int i = 0; i < spawnPoints.Length; i++)
        {
            //do something
            //if (randomIndex != i && randomIndex2 != i && randomIndex3 != i && rand)
            if(i == randomIndex || i == randomIndex2 || i == randomIndex3 || i == randomIndex4)
            {
                int randomCrit = Random.Range(0, seaCrits.Length);

                GameObject jelly = seaCrits[randomCrit].GetPooledObject();
                jelly.transform.position = spawnPoints[i].position;
                jelly.SetActive(true);

                //Instantiate(seaCrits[randomCrit].GetPooledObject(), spawnPoints[i].position, spawnPoints[i].rotation);
                //Instantiate(astroidPrefab, spawnPoints[i].position, Quaternion.identity);
                //Instantiate(asteroidTypes[Random.Range(0,asteroidTypes.Length)], spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

    void spawnSingleProjectile()
    {
        
        int randomIndex = Random.Range(0, spawnPoints.Length);
       	int randomCrit = Random.Range(0, seaCrits.Length);

		GameObject jelly = seaCrits[randomCrit].GetPooledObject();
        jelly.transform.position = spawnPoints[randomIndex].position;
        jelly.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        jelly.SetActive(true);
		jelly.GetComponent<Jellyfish>().moveJelly();

        //Instantiate(asteroids[randomAstro].GetPooledObject (), spawnPoints[randomIndex].position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        //Instantiate(astroidPrefab, spawnPoints[randomIndex].position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));//Quaternion.identity);
    }

    void spawnPortal()
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);
        Vector3 vec = spawnPoints[randomPoint].transform.position;
        PG.SpawnPortal(vec);
        //Instantiate(portalPrefab, spawnPoints[i].position, Quaternion.identity);

    }
}
