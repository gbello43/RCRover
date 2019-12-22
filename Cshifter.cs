using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cshifter : MonoBehaviour 
{
	private float startBound;
	private float endBound; 

	private bool activated;

	private bool movePositive;

	// Use this for initialization
	void Start () 
	{
		activated = true;
		startBound = transform.position.x;
		endBound = startBound + 8.0f;
		movePositive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!activated)
			return;

		if (movePositive) 
		{
			transform.Translate ((endBound - startBound) / 180.0f, 0, 0);
		} 
		else 
		{
			transform.Translate (-(endBound - startBound) / 180.0f, 0, 0);
		}

		if (transform.position.x > endBound)
			movePositive = false;
		if (transform.position.x < startBound)
			movePositive = true;
	}

	public void activateC()
	{
		activated = true;
	}
}