using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleActivateTargetOnce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(gameObject.name) && PlayerPrefs.GetString(gameObject.name) == "showed_once")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
