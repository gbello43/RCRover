
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour {

	public Animator animator;
	public Sprite[] sprites;
	private SpriteRenderer roverSprite;

	public GameObject leftThrust ;
	public GameObject rightThrust;
    public GameObject shield;
    public ParticleSystem sparkles;
	public GameObject leftheadLights;
	public GameObject rightheadlights;

	public float highJumpMultiplier;
	public float lowJumpMultiplier;

	public float thrust;		//contains X velocity which can be modified in inspector
	public bool boost = false;

	public MeterControl meter;
    public bool onGround;
    public bool canDoubleJump;

	private float moveSpeedStore;	//save/set move speed
    float moveSpeed;
    public float speedMultiplier;
	public float gravity;

	private float speedMileStoneCountStore;
    private float speedIncreaseMileStone;
	private float speedIncreaseMileStoneStore;
    private float speedMileStoneCount;      //add to Milestone

    Rigidbody2D rb;
    [Range(1, 10)]
    public float jumpVelocity;
    private SoundManager soundManager;
	private DeathMenu theDeathMenu;
    private ScoreManager theScoreManager;
	private PauseMenu PM;
	public GameManager theGameManager;

	//private Vector2 startP = new Vector2(0f,3.5f);
	private Vector2 crashPoint = new Vector2(0,0);
    private Vector2 roofCrashPoint = new Vector2(0, 0);
    // Use this for initialization
    void Start() {

		roverSprite = gameObject.GetComponent<SpriteRenderer>();
		sprites = Resources.LoadAll<Sprite>("roverShell");
		gravity = 4;
		highJumpMultiplier = 4f;
		lowJumpMultiplier = 6f;
        theScoreManager = FindObjectOfType<ScoreManager>();
        //moveSpeed = PlayerPrefs.GetFloat ("SSSpeed");		//Sets moveSpeed for player
		PM = FindObjectOfType<PauseMenu>();
		leftThrust.SetActive (false);
		rightThrust.SetActive (false);

		//moveSpeed = 20.0f;//PlayerPrefs.GetFloat ("SSSpeed");
		moveSpeedStore = 20.0f;

		speedIncreaseMileStone = 500f;
		speedMileStoneCountStore = speedMileStoneCount;
		speedIncreaseMileStoneStore = speedIncreaseMileStone;

        soundManager = SoundManager.instance;
        if(soundManager == null)
        {
            Debug.LogError("No audioManager found in scene");
        }
        rb = GetComponent<Rigidbody2D>();

        speedMileStoneCount = speedIncreaseMileStone;
    }

    // Update is called once per frame
    void Update() {

        

        if (onGround == true) {
            meter.IncreaseGauge(0.002f);
        }
        
		if (boost == true) {
            shield.SetActive(true);
			meter.DecreaseGauge (0.02f);
			rb.velocity = new Vector2(moveSpeed * thrust, 0);		//moves player forward
			GetComponentInChildren<ParticleSystem>().Play();

		} 
		else {
            shield.SetActive(false);
            GetComponentInChildren<ParticleSystem>().Stop();

			rb.velocity = new Vector2(moveSpeed, rb.velocity.y);		//moves player forward

		}

		//Increase Speed based on milestone


        if (transform.position.x > speedMileStoneCount)
        {
			
				speedMileStoneCount += speedIncreaseMileStone;

				speedIncreaseMileStone = speedIncreaseMileStone * speedMultiplier;
			if (moveSpeed >= 36.0f) {

				moveSpeed = 36.0f;
			} else {
				moveSpeed = moveSpeed * speedMultiplier;
			}
			
        }


    }

    void LateUpdate()
    {
        //checkCrash();
    }

    void checkCrash()
    {

        Vector2 dirRight = new Vector2(1, 0);		//direction to the right

        if (transform.position.x > 10f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirRight, 8f);
            Vector2 curPos = new Vector2(transform.position.x, transform.position.y);



            if (PM.isPaused == true)
            {
                return;
            }
            else if (curPos == crashPoint)
            {
                theGameManager.DeathScreen();

            }
            else if (hit.collider != null)
            {
                crashPoint = new Vector2(hit.point.x, hit.point.y);

            }

           
        }
    }
	public float getSpeed(){
		return moveSpeed;
	
	}
	public void headLightsActive(){
		if(leftheadLights.activeSelf == false){
			leftheadLights.SetActive(true);
			rightheadlights.SetActive(true);
		}
		else if(leftheadLights.activeSelf == true){
			leftheadLights.SetActive(false);
			rightheadlights.SetActive(false);
		}
	}
	public void headLightsOff(){
		leftheadLights.SetActive(false);
		rightheadlights.SetActive(false);
	}

	IEnumerator waitStart()
	{
		yield return new WaitForSeconds (5);
	}
	//Button hold
	public void jumpHigh(){	

		if (leftThrust.activeSelf == false) {
			thrusterActivation (true);
		}

		meter.DecreaseGauge (0.05f);

		rb.AddForce(Vector2.up * highJumpMultiplier, ForceMode2D.Impulse);

		onGround = false;

	}
	
    //Button click

	public void jumpLow()
    {
		
		meter.DecreaseGauge (0.02f);

		rb.AddForce(Vector2.up * lowJumpMultiplier, ForceMode2D.Impulse);

		onGround = false;
	}
   
    //reset gravty back to 1
	public void deactivateThruster(){
		if (leftThrust.activeSelf == true) {
			thrusterActivation (false);
		} 

	}
	public void modifyGravity(float LJ, float HJ, float g){

		lowJumpMultiplier = LJ;
		highJumpMultiplier = HJ;
		gravity = g;

	}
	public void thrusterActivation(bool change){
		leftThrust.SetActive (change);
		rightThrust.SetActive (change);
	}
	public void BoostOn(){      //boost set to true

		boost = true;
	}
	public void BoostOff(){ //boost set to false

		boost = false;
	}
    //on collision with ground 
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {        //collision detects the ground 
			
            onGround = true;                    //sets onGround back to true 
        }
        
    }
	void FixedUpdate(){
		rb.gravityScale = gravity;

	}
   //on trigger with various gameObjects
	void OnTriggerEnter2D(Collider2D col){
		

		if (col.gameObject.tag == "Crystal")
        {
			Debug.Log("crystal");
			if (boost == true) {
				soundManager.PlaySound("Glass");
				col.gameObject.GetComponent<Crystals> ().Shatter ();
				meter.IncreaseGauge(0.5f);
				col.gameObject.SetActive(false);
			}
			else {
				crashedDeath();
				//StartCoroutine(coroutine);

			//	Instantiate(crashExplosion, transform.position, Quaternion.identity);



			}
        }
        else if (col.gameObject.tag == "Orb") {     //adds orbs to counter
            theScoreManager.addOrbs();
            col.gameObject.SetActive(false);
        }
        else if (col.gameObject.tag == "astroid")
        {
			if (boost == true) {
				col.gameObject.GetComponent<astroid> ().explode ();
				col.gameObject.SetActive (false);
                meter.IncreaseGauge(0.6f);


            }
            else {
				crashedDeath();
			}
		}
        else if (col.gameObject.tag == "smallAsteroid")
        {
			
            if (boost == true)
            {
                col.gameObject.GetComponent<astroid>().explode();
                col.gameObject.SetActive(false);
                meter.IncreaseGauge(0.4f);


            }
            else
            {
				crashedDeath();
            }
        }
        else if (col.gameObject.tag == "bigAsteroid")
        {
            if (boost == true)
            {
                col.gameObject.GetComponent<astroid>().explode();
                col.gameObject.SetActive(false);
                meter.IncreaseGauge(0.8f);


            }
            else
            {
				crashedDeath();
            }
        }
    }
	public void crashedDeath()
	{
		Debug.Log("crashedDeath");
		rb.velocity = new Vector2(0,0);
		modifyGravity(0,0,0);
		animator.SetBool("isDead", true);
		FindObjectOfType<GameManager> ().DeathScreen ();
	}
	IEnumerator waitCrashDeathScreen(float seconds)
	{
		Debug.Log("explode");
		yield return new WaitForSeconds(seconds);
		FindObjectOfType<GameManager> ().DeathScreen ();
	}

	public void setMoveSpeed(float mp){

		moveSpeed = mp;

	}
	IEnumerator crashDeath()
	{
		yield return new WaitForSeconds (3f);
		FindObjectOfType<GameManager> ().DeathScreen ();

	}
    //game over resets levels defaults
    public void GameOver() {
		animator.SetBool("isDead", false);
        theScoreManager.resetCounters();
        //PlayerPrefs.SetFloat("Score", 0f);
		//roverSprite.sprite = sprites[0];
		//moveSpeed = moveSpeedStore;
		speedMileStoneCount = speedMileStoneCountStore;
		speedIncreaseMileStone = speedIncreaseMileStoneStore;
		meter.resetGauge ();
        thrusterActivation(false);
		BoostOff ();
		modifyGravity (6f, 4f, 4f);
		//FindObjectOfType<PlayertrackCam> ().resetCamera ();
    }


}
