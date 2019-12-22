using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {
	public Text scoreText;
	// Use this for initialization
    public ScoreManager sm;
    //calls reset method
	public NewBehaviourScript player;
	public cameraMove movingPlatform;
	public cameraMove mainCam;

    void Start()
    {

	}
	public void RestartGame(){

		FindObjectOfType<GameManager> ().Reset ();
		movingPlatform.restartEngine();
		mainCam.back();
		//player.setMoveSpeed(17.0f);
		//player.setMoveSpeed(20.0f);

	}

    public void setScoreToMenu()
    {
        scoreText.text = "" + Mathf.Round(sm.getScore());
    }
	public void QuitToMain(){
		FindObjectOfType<PauseMenu>().disablePUI();
		FindObjectOfType<GameManager> ().Reset ();
		player.setMoveSpeed(0);
		FindObjectOfType<Menu>().ActivateMainMenu();
		FindObjectOfType<Menu>().backToMain();

		//mainCam.back();
		//player.setMoveSpeed(0.0f);

	}
}
