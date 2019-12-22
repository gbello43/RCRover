using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{


    public Image mainCanvas;
    public Image menu;
    public Button LabButton;
    public Button playButton;
    public NewBehaviourScript player;

    public cameraMove camera;
    float alphaLevel = 1f;
    int canvas = 0;
    bool fadeIn = false;
    bool fadeOut = false;
    bool play = false;

	public cameraMove movingPlatform; 
	private float startS = 3.6f;

    // Start is called before the first frame update
    void Start()
    { 
        
        //camera = FindObjectOfType<cameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn == true)
        {
            FadeCanvasIn();
        }
        else if (fadeOut == true)
        {
            FadeCanvasOut();
        }

      

    }

    public void FadeCanvasIn() {

        switch (canvas)
        {
            case 1:
                if (alphaLevel == 0.5f)
                {
                    canvas = 0;
                    fadeIn = false;

                }
                else
                {
                    alphaLevel += 0.01f;

                    mainCanvas.color = new Color(1, 1, 1, alphaLevel);
                }
                break;
            case 2:
                if (alphaLevel == 0.5f)
                {
                    canvas = 0;
                    fadeIn = false;
                }
                else
                {
                    alphaLevel += 0.01f;

                    menu.color = new Color(1, 1, 1, alphaLevel);

                }
                break;
            default:
                break;
        }

        
    }

    public void FadeCanvasOut()
    {

        switch (canvas)
        {

            case 1:
                if (alphaLevel == 0)
                {
                    canvas = 0;
                    fadeOut = false;
                }
                else
                {
                    alphaLevel -= 0.01f;

                    mainCanvas.color = new Color(1, 1, 1, alphaLevel);
                }
                break;
            case 2:
                if (alphaLevel == 0)
                {
                    canvas = 0;
                    fadeOut = false;
                }
                else
                {
                    alphaLevel -= 0.01f;

                    menu.color = new Color(1, 1, 1, alphaLevel);

                }
                break;
            default:
                break;
        }
       
    }

    public void PlayButton()
    {
		mainCanvas.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        LabButton.gameObject.SetActive(false);
        //alphaLevel = mainCanvas.color.a;
        //fadeOut = true;
        //canvas = 1;
		movingPlatform.forward();
		StartCoroutine("waitForEngine");
		//player.setMoveSpeed(10.0f);
		//gameObject.GetComponent<PauseMenu>().enablePUI();
    }

	IEnumerator waitForEngine()
	{
		yield return new WaitForSeconds (startS);
		player.setMoveSpeed(17.0f);

	}
	IEnumerator waitToActivateButtons(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		activateButtons();

	}
	public void ActivateMainMenu(){
		mainCanvas.gameObject.SetActive(true);
		//fadeIn = true;
		//canvas = 1;

	}
	public void activateButtons()
	{
		playButton.gameObject.SetActive(true);
		LabButton.gameObject.SetActive(true);

	}
	public void deactivateButtons()
	{
		playButton.gameObject.SetActive(false);
		LabButton.gameObject.SetActive(false);

	}
	public void labButton(){
		
		mainCanvas.gameObject.SetActive(false);
		menu.gameObject.SetActive(true);
		camera.forward();
		movingPlatform.forward();
		deactivateButtons();
		startS = 1.0f;
		//playButton.gameObject.SetActive(false);
		//LabButton.gameObject.SetActive(false);



	}
	public void backToMain(){
		mainCanvas.gameObject.SetActive(true);
		menu.gameObject.SetActive(false);
		camera.back();
		IEnumerator coroutine = waitToActivateButtons(4.3f);
		StartCoroutine(coroutine);


	}
    public void fadeMainIn()
    {
        camera.back();
        menu.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
        /*alphaLevel = mainCanvas.color.a;
        fadeIn = true;
        canvas = 1;
        */
    }
    public void fadeMainOut()
    {
        camera.forward();
        mainCanvas.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        /*playButton.gameObject.SetActive(false);
        LabButton.gameObject.SetActive(false);
        alphaLevel = mainCanvas.color.a;
        fadeOut = true;
        canvas = 1;
        */
    }

    public void fadeMenuIn()
    {
        alphaLevel = menu.color.a;
        fadeIn = true;
        canvas = 2;

    }
    public void fadeMenuOut()
    {
        alphaLevel = mainCanvas.color.a;
        fadeOut = true;
        canvas = 2;
    }

}
