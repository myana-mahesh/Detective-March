using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnPickup : MonoBehaviour {

	public GameObject activateObject;

	public void OnMouseDown(){
		activateObject.SetActive(true);
	}
}
