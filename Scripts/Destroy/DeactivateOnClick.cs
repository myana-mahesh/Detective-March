using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnClick : MonoBehaviour {

	public GameObject deactivateObject;

	public void OnMouseDown(){
		deactivateObject.SetActive(false);
	}
}
