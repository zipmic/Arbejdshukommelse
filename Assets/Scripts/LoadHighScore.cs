using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighScore : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        GetComponent<Text>().text = "Highscore: "+"\n"+PlayerPrefs.GetInt("Highscore").ToString();
	}

}
