﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
	public GameObject myCurrentScreen;
//	public GameObject myInventory;

	public void OnMouseDown ()
	{
//		SoundManager.Instance.gameSounds[2].Play();
		myCurrentScreen.SetActive(false);
		SoundManager.Instance.gameSounds[0].Play();
		// todo drag myinventory here 
//		myInventory.SetActive(true);
	}
}
