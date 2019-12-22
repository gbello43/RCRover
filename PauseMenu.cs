using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {


	public GameObject mainScreen;

    public bool isPaused;

	public GameObject Meter;
	public GameObject Score;
	public GameObject Orbs;

    public GameObject pauseMenuPanel;
	public GameObject playerUI;
    public GameObject pauseButton;
	public GameObject leftButton;
	public GameObject rightButton;


    // Update is called once per frame
    public void Start()
    {
		disablePUI();
        isPaused = false;

		//disable();
	}
    public void Update () {

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseButton.SetActive(false);
            pauseMenuPanel.SetActive(true);

        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
       
     }

    public void pause()
    {
		Debug.Log("Paused");
		disable ();		//disable buttons
        isPaused = true;
    }
    //resume gameplay
    public void Resume()
    {
		pauseButton.SetActive(true);

		enable ();
        isPaused = false;
    }
    
    //exit to main menu
    public void Exit()
    {
        SceneManager.LoadScene(0);
		isPaused = false;
        
    }
    //enable right/left buttons
	public void enable(){
		
		leftButton.SetActive (true);
		rightButton.SetActive (true);
	}
	//disable right/left buttons
	public void disable(){
		leftButton.SetActive (false);
		rightButton.SetActive (false);
	
	}
	//enable player userInterface
	public void enablePUI(){
		enable();	//enable buttons
		disableMainScreen();
		playerUI.SetActive(true);
		/*
		Meter.SetActive(true);
		Score.SetActive(true);
		Orbs.SetActive(true);

		pauseButton.SetActive(true);
		leftButton.SetActive(true);
		rightButton.SetActive(true);	
		*/
	}
	//disable player userInterface
	public void disablePUI(){
		
		disable();	//disable buttons
		//Meter.SetActive(false);
		playerUI.SetActive(false);
		/*
		Score.SetActive(false);
		Orbs.SetActive(false);

		pauseButton.SetActive(false);
		leftButton.SetActive(false);
		rightButton.SetActive(false);
		*/
	}
	public void enableMainScreen()
	{
		mainScreen.SetActive (true);
	}
	public void disableMainScreen(){
		mainScreen.SetActive (false);
	}
	public bool checkPaused(){

		return isPaused;
	}
}
