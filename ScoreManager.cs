using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;

    public Text OrbCounterText;
	public Text ShardCounterText;
	public Text PlutoniumCounterText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

    public int orbCount;
	public int shardCount;
	public int plutoniumCount;


	// Use this for initialization
	void Start () {
        orbCount = PlayerPrefs.GetInt("OrbCount");
        scoreCount = PlayerPrefs.GetFloat("Score");

		if(PlayerPrefs.HasKey("HighScores"))
		{
			hiScoreCount = PlayerPrefs.GetFloat("HighScore");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
        
		if (scoreIncreasing) 
		{
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		if (scoreCount > hiScoreCount) 
		{
			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
		}

		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);

        OrbCounterText.text = "" + orbCount;
		ShardCounterText.text = "" + shardCount;
		PlutoniumCounterText.text = "" + plutoniumCount;


	}
    public int getOrbCount() {
        return orbCount;
    }
	public int getShardCount()
	{
		return shardCount;
	}
	public int getPlutoniumCount()
	{
		return plutoniumCount;
	}
    public void addOrbs() {
        orbCount += 1;
    }
	public void addShard()
	{
		shardCount += 1;
	}
	public void addPlutonium()
	{
		plutoniumCount += 1;
	}
	public void resetCounters()
	{
		orbCount = 0;
		shardCount = 0;
		plutoniumCount = 0;

	}
    public float getScore() {
        return scoreCount;
    }
	public void AddScore(int pointsAdded)
	{
		scoreCount += pointsAdded;			
	}

}
