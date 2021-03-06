﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeText : MonoBehaviour {

    public bool isRunning = false;
    public UnityEngine.UI.Text TextToDisplay;

    public float TimeLeft = 120;
	public Quest QuestGiver; 
	// Use this for initialization
	void Start () {

        TextToDisplay.text = "Tid: " + TimeLeft;
		
	}

	// Update is called once per frame
	void Update () {

        if (isRunning)
        {
            TimeLeft -= Time.deltaTime;
            TextToDisplay.text = "Tid: " + ((int)TimeLeft).ToString();

            if(TimeLeft <= 0)
            {
				// end game
				int Score = QuestGiver.GetFinalScore();
				//set highscore
				/*if (Score > PlayerPrefs.GetInt("Highscore"))

			
				{
					PlayerPrefs.SetInt("Highscore", Score);

				}
				*/

				PlayerPrefs.SetInt("CurrentScore", Score);

				isRunning = false;



				UnityEngine.SceneManagement.SceneManager.LoadScene("MoneyGrab");
            }
        }
		
	}
}
