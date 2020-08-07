using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleActivateHideOnce : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
        {
            if (PlayerPrefs.GetString(gameObject.name) == "showed_once")
            {
                Debug.Log("<b>Object Showing</b> " + gameObject.name);
                gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetString(gameObject.name) == "hidden_once")
            {
                Debug.Log("<b>Object Hiding</b> " + gameObject.name);
                gameObject.SetActive(false);
            }
        }
    }



}
