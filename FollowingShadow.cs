using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingShadow : MonoBehaviour {

	public NewBehaviourScript Target; //thePLayer
	// Use this for initialization
	void Start () {
		
		Target = FindObjectOfType<NewBehaviourScript>();

	}

	// Update is called once per frame
	void Update () {
		
		float speed = Target.getSpeed () - 0.3f;
		//move towards target
		transform.position = Vector2.MoveTowards (transform.position, Target.transform.position, speed * Time.deltaTime);
        //if camera and player position overlap Game Over
		if (transform.position.x == Target.transform.position.x) {
			FindObjectOfType<GameManager> ().DeathScreen ();

		}
	}
}
