using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MAINMENU : MonoBehaviour
{

	void Start(){

        //set variables to 0
		PlayerPrefs.SetFloat ("Score", 0);		//Globle Score
		//PlayerPrefs.SetFloat ("SSSpeed", 20.0f);	//SS move speed
		PlayerPrefs.SetInt("SSDif",0);          //Sets SS difficulty
        PlayerPrefs.SetInt("OrbCount", 0);
        PlayerPrefs.SetInt("nextLevel", 1);

        //if highscore exists set it else set to 0
        if (PlayerPrefs.HasKey("HIGHSCORE"))
        {
            PlayerPrefs.SetFloat("HIGHSCORE", PlayerPrefs.GetFloat("HIGHSCORE"));
        }
        else
        {
            PlayerPrefs.SetFloat("HIGHSCORE", 0);
        }
    }

    public void PlayButton()
    {
		
        SceneManager.LoadScene(1);
		/*PM.disableMainScreen();
		PM.enablePUI ();
		PM.Resume ();
		thePlayer.setMoveSpeed (20.0f);
		*/

    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
