using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{

	public Text highscore;

	// Use this for initialization
	void Start ()
    {
		    highscore.text = "Highscore: " + PlayerPrefs.GetInt ("Highscore");
	}
}
