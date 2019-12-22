using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Animator animator;
	public GameObject playerUI;
	public GameObject menuUI;

	private ScoreManager theScoreManager;

	private int upperBound = 31, lowerBound = -31;

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public Transform hostilePlatGenerator;
	private Vector3 hostilePlatStartPoint;

	public FollowingShadow shadow;
	public NewBehaviourScript thePlayer;
	//public PlayerMoveForward player3D;
	private Vector3 playerStartPoint;
	//private Vector3 startPoint3D;


    public ProjectileGenerator projectiles;
    public Vector3 projectileStartPoint;

	private PlatformDestroyer[] platformList;
    private ObjectDestroyer[] astroidList;
	private ObjectDestroyer[] ObjectList;

	private cameraManager CM;

	public DeathMenu theDeathMenu;

	int next = 1;//, max = 1;
	bool thruPortal = false;
	int nextLevel = 0;		//gets the current active camera

	//public Text liveScore;

	// Use this for initialization
	void Start () {
        //starting positions of player and platforms
        //liveScore.text =  PlayerPrefs.GetFloat("SCORE").ToString();	//get global variable Score
        //starting positions of game objects


		CM = FindObjectOfType<cameraManager> ();
        theScoreManager = FindObjectOfType<ScoreManager>();
		//Start Point for platform Generators
        platformStartPoint = platformGenerator.position;
		hostilePlatStartPoint = hostilePlatGenerator.position;

        //platformGenerator.position = platformStartPoint;


		//startPoint3D = player3D.transform.position;
        playerStartPoint = thePlayer.transform.position;
		thePlayer.transform.position = playerStartPoint;

		nextLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//liveScore.text = GetComponent<Scoring>().GetScoreAsInt().ToString();    //updates live score
		if (thruPortal == true) 
		{
			return;
		}
		else if(thePlayer.transform.position.y > upperBound || thePlayer.transform.position.y < lowerBound){
			DeathScreen();
			//FindObjectOfType<GameManager>().DeathScreen();
		}
	}
	public void setBoundsNull()
	{
		thruPortal = true;
	}
	public void setBounds (int nextLevel)
	{
		switch (nextLevel) {
		case 1:
			thePlayer.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f);

			upperBound = 31;
			lowerBound = -31;
			break;
		case 2:
			upperBound = 140;
			lowerBound = 80;
			break;
        case 3:

            upperBound = 257;
            lowerBound = 189;
            break;
		case 4:
			thePlayer.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f);

			upperBound = 390;
			lowerBound = 337;
			break;
        default:
			thePlayer.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f);

			upperBound = 600;
			lowerBound = -600;
			break;

		}
		thruPortal = false;
	}
	public int getNext()
	{
		return next;

	}
	public void switchLevel()
	{
		
		//int nextLevel = CM.getActive ();		//gets the current active camera
		setBoundsNull();
		//modifyGravity(highJump, lowJump, gravity)
		if (nextLevel == 4) {
			nextLevel = 1;
			thePlayer.modifyGravity (6f, 4f, 4f);
			CM.switchCamera (nextLevel);
			thePlayer.gameObject.SetActive (true);
			//player3D.gameObject.SetActive (false);
			setBounds (nextLevel);
		} 
		
		else {
			nextLevel++;
		
			if (nextLevel == 2) {

				thePlayer.modifyGravity (2f, 5f, 1f);
				
			}
			else if(nextLevel == 4){
				thePlayer.modifyGravity(7f,3f,5f);

			}
			CM.switchCamera (nextLevel);
			setBounds (nextLevel);

		}

	}
	public void leftButtonPointerDown(){
		
			thePlayer.jumpHigh ();

	
	}
	public void leftButtonPointerUp(){
		
			thePlayer.deactivateThruster();
			
	}
	public void leftButtonPointerClick(){
		
			thePlayer.jumpLow ();

	}
	public void rightButtonPointerDown(){
		
			thePlayer.BoostOn ();

	}
	public void rightButtonPointerUp(){
		
			thePlayer.BoostOff ();

	}
	public void DeathScreen(){
        //FindObjectOfType<Scoring>().YouDied();//PauseScore ();

		Debug.Log("DeathScreen");

		thePlayer.headLightsOff();
		thePlayer.setMoveSpeed(0f);

        theScoreManager.scoreIncreasing = false;
       // thePlayer.gameObject.SetActive (false);
       
        projectiles.GetComponent<ProjectileGenerator>().deactivate();
        
        FindObjectOfType<PauseMenu> ().disablePUI ();
        //theDeathMenu.ToggleDeath();
        //theDeathMenu.gameObject.SetActive (true);
        theDeathMenu.setScoreToMenu();

        setBounds(0);

		StartCoroutine("waitForDeathAnimation");
		//thePlayer.transform.position = playerStartPoint;
		//CM.resetCameras ();

    }
	IEnumerator waitForDeathAnimation(){
		yield return new WaitForSeconds(1f);
		//thePlayer.gameObject.SetActive (false);
		CM.resetCameras ();
		thePlayer.transform.position = playerStartPoint;
		theDeathMenu.gameObject.SetActive (true);


	}
    //reset games values
    public void Reset(){

		//thePlayer.transform.position = playerStartPoint;

        //thePlayer.gameObject.SetActive (false);
		ObjectList = FindObjectsOfType<ObjectDestroyer> ();
	
		for (int i = 0; i < ObjectList.Length; i++)
		{     //finds all objects with 'platformDestroyer' and sets them to false
			ObjectList[i].gameObject.SetActive(false);  //return to objectPool as false

		}

		platformGenerator.position = platformStartPoint;
		hostilePlatGenerator.position = hostilePlatStartPoint;

		projectiles.GetComponent<ProjectileGenerator>().Active();

        
        //thePlayer.transform.position = playerStartPoint;

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
		//CM.resetCameras ();
		nextLevel = 0;

		theDeathMenu.gameObject.SetActive (false);
		thePlayer.gameObject.SetActive (true);
		FindObjectOfType<NewBehaviourScript> ().GameOver ();

	}
			

}
