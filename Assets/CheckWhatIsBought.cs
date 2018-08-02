using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CheckWhatIsBought : MonoBehaviour
{

	public FirstPersonController PlayerFPS;


	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.GetInt("SpeedBoost") == 1)
		{
			PlayerFPS.m_RunSpeed = 24;
		}











	}

}
