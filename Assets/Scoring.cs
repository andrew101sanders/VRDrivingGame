using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public static Scoring i;
    public int enemiesKilled = 0;
    public int laps = 0;
    public float timeLastedFloat = 0f;
    public bool playing = false;
    public bool scoreTime = false;

	void Awake () {
        if(i == null)
        {
            i = this;
            DontDestroyOnLoad(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
        
	}

    public void startTimer()
    {
        GetComponent<Text>().enabled = false;
        playing = true;
    }

    public void stopTimer()
    {
        playing = false;
    }

    void Update()
    {
        if (playing)
        {
            timeLastedFloat += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "MenuScene" && scoreTime == true)
        {
            calcScore();
        }
    }

    public void increaseKilled()
    {
        enemiesKilled++;
    }

    public void increaseLaps()
    {
        laps++;
    }

    void calcScore()
    {
        float score = (enemiesKilled * 10) + (laps * 5) + Mathf.FloorToInt(timeLastedFloat);
        GetComponent<Text>().enabled = true;
        GetComponent<Text>().text = "\nScore\n----------------------------\n" + "Enemies Defeated = " + enemiesKilled + "\n Distance Traveled = " + laps + "\n Time Lasted = " + Mathf.FloorToInt(timeLastedFloat) + " Seconds\n\n\n Final Score\n-------------\n" + score;
        enemiesKilled = 0;
        laps = 0;
        timeLastedFloat = 0f;
        GameObject.Find("authorship").GetComponent<Image>().enabled = false;
        scoreTime = false;
    }
}
