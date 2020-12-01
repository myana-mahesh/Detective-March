using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleActivateTargetOnce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FileBasedPrefs.HasKey(gameObject.name) && FileBasedPrefs.GetString(gameObject.name) == "showed_once")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
