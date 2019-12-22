using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour {

    public int scoreToGive;
	public int obj;

    private ScoreManager ScoreManager;

	public GameObject floatingText;
	public GameObject collectOrbEffect;
	public Animator animator;
   
	// Use this for initialization
	void Start () {
		
        ScoreManager = FindObjectOfType<ScoreManager>();

	}
	 
	// Update is calledonce per frame
	void Update () {

	
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {

            ScoreManager.AddScore(scoreToGive);
			showfloatingText ();
			//animator.SetBool("collect", true);

			switch(obj)
			{
				case 1:
					ScoreManager.addOrbs();
					break;

				case 2:
					ScoreManager.addShard();
					break;

				case 3:
					ScoreManager.addPlutonium();
					break;

				default:
					Debug.Log("Scoremanager Collect Null");
					break;
				}
		}
    }

    void showfloatingText()
	{
		
		var go = Instantiate (floatingText, transform.position, Quaternion.identity);

		go.GetComponent<TextMesh> ().text = scoreToGive.ToString();

	}
	void collectOrb()
	{
		var go = Instantiate(collectOrbEffect, transform.position, Quaternion.identity);

	}
}
