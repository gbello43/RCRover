using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    public float scrollSpeed = 10.0f;
    public GameObject[] challenges; //array of gameObjects
    public float frequency = 0.5f;  //frequency of generated gameObjects
    float counter = 0.0f;
    public Transform challengesSpawnPoint;
    
   

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Scrolling
        GameObject currentChild;

        for (int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;

            ScrollerChallenge(currentChild);

            if (currentChild.transform.position.x <= -25) {

                Destroy(currentChild);
                scrollSpeed += 0.5f;
            }
        }
        
	}

    void IncreaseSpeed(float speed) {
        scrollSpeed += speed;
    }
    void ScrollerChallenge(GameObject currentChallenge) {

        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }
    //generates random obsticles
    void GenerateRandomChallenge()
    {

        Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity);

        counter += 1;
    }



}
