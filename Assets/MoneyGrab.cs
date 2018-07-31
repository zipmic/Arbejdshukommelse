using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using UnityEngine.SceneManagement;

public class MoneyGrab : MonoBehaviour {

	public Text YourScore, TotalMoneyCountText;

	private int _currentMoney;
	private int _currentScore;

	// Use this for initialization
	void Start ()
	{


		_currentScore = PlayerPrefs.GetInt("CurrentScore");
		_currentMoney = PlayerPrefs.GetInt("PlayerMoney");
		YourScore.text = "Score: " + _currentScore;
		TotalMoneyCountText.text = "X "+ _currentMoney;
		StartCoroutine(GiefMoneyAndLoadStart());
	}
	
	// Update is called once per frame
	void Update ()
	{
		YourScore.text = "Score: " + _currentScore;
		TotalMoneyCountText.text = "X " + _currentMoney;
	}

	IEnumerator GiefMoneyAndLoadStart()
	{
		yield return new WaitForSeconds(1);
		int AmountOfMoneyEarned = _currentScore;
		for (int i = 0; i < AmountOfMoneyEarned; i++)
		{
			_currentScore--;
			_currentMoney++;
			yield return new WaitForSeconds(0.2f);
		}
		PlayerPrefs.SetInt("PlayerMoney", _currentMoney);

		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(0);
	}
}
