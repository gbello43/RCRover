using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGenerator : MonoBehaviour {

    public ObjectPooler[] crystalPool;
	//private Vector2 dir = new Vector2 (0, -1);	//direction for raycast
    //how to generate crytals distance between Crystals
    public float distanceBetweenCrystals;

    // Use this for initialization

        //create the crystals and spawn them
    public void SpawnCrystal(Vector2 startPosition)
    {
        //create crystal
		int rnd = Random.Range(0, crystalPool.Length);
			
        GameObject crystal1 = crystalPool[rnd].GetPooledObject();    //new object crystal 1
        
		crystal1.transform.position = startPosition;//set position of it 

        crystal1.SetActive(true);//create in game

    }
}
