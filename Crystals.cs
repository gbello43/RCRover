using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour {
	public GameObject glassShatter;


	public void Shatter(){
	
		Instantiate (glassShatter, transform.position, transform.rotation);
	}
}
