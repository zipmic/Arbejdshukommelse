using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoins : MonoBehaviour {

	public Text CoinText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		CoinText.text = "X " + PlayerPrefs.GetInt("PlayerMoney");
		
	}
}
