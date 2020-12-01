using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnClick : MonoBehaviour {

	
	public GameObject deactivateObject;

	public bool haveMultiple;
	public GameObject[] deactivateObjects;

	public bool actiavteObject;
	public GameObject[] actiavteObjects;
	public void OnMouseDown(){
		if(haveMultiple){
			foreach (GameObject item in deactivateObjects)
			{
				item.SetActive(false);
			}
		}
		else
		{
		deactivateObject.SetActive(false);
		}
		if(actiavteObject){
			foreach (GameObject item in actiavteObjects)
			{
				item.SetActive(true);
			}
		}
	}
}
