using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++) {

            GameObject obj = (GameObject) Instantiate(pooledObject);  //casting gameObject
            obj.SetActive(false);
            pooledObjects.Add(obj); //add to list
        }
		
	}
    //returns object that is not active
    public GameObject GetPooledObject()
    {

        for(int i = 0; i < pooledObjects.Count; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)        //return if not active
            {

                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);  //casting gameObject
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
