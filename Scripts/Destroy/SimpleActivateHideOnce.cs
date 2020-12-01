using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleActivateHideOnce : MonoBehaviour
{

    void Start()
    {
        if (FileBasedPrefs.HasKey(gameObject.name))
        {
            if (FileBasedPrefs.GetString(gameObject.name) == "showed_once")
            {
                Debug.Log("<b>Object Showing</b> " + gameObject.name);
                gameObject.SetActive(true);
            }
            else if (FileBasedPrefs.GetString(gameObject.name) == "hidden_once")
            {
                Debug.Log("<b>Object Hiding</b> " + gameObject.name);
                gameObject.SetActive(false);
            }
        }
    }



}
