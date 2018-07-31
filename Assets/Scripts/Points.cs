using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	private int _amountOfCorrectPoints = 0;

	public UnityEngine.UI.Text PointText;


	public void AddCorrectPoint()
	{
		_amountOfCorrectPoints++;
		PointText.text = _amountOfCorrectPoints.ToString();
	}

    public void SaveHighscore()
    {
        if (PlayerPrefs.GetInt("Highscore") <= _amountOfCorrectPoints)
        {
            PlayerPrefs.SetInt("Highscore", _amountOfCorrectPoints);
        }
    }
}
