using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenClickedInSecs : MonoBehaviour {

	public void Start()
	{
		Invoke ("ItemDisplay", 0);
	}

	public void ItemDisplay()
    {
		// todo save hog 
		if (PlayerPrefs.HasKey(gameObject.name+"1")) {
			gameObject.SetActive(false);
			return;
		}
		else {
			/*if (Input.GetMouseButtonUp(0)){
				PlayerPrefs.SetString(gameObject.name,"showed_once");
				gameObject.SetActive(false);
			}*/
		}
	}

    private void OnMouseDown() {
        PlayerPrefs.SetString(gameObject.name + "1", "showed_once");
        gameObject.SetActive(false);
    }
}
