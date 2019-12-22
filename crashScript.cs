using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerEnter2D (Collider2D other)
	{
		//int next = PlayerPrefs.GetInt ("nextLevel");

		if (other.name == "Player") 
		{
			Debug.Log("PlatformCrash");
			//FindObjectOfType<GameManager> ().DeathScreen ();
			FindObjectOfType<NewBehaviourScript>().crashedDeath();
		}

	}
}
