using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpriteActivateOnce : MonoBehaviour
{
    [Header("Should be true only when this gameobject's sprite is enabled after an object is dropped on this")]
    [Header("For example puzzle pieces sprites that are being enables in chained drawer when puzzles are being dropped")]
    public bool initialEnableBoxCollider;
    void Start()
    {
        string spName = GetComponent<SpriteRenderer>().sprite.name;
        if (FileBasedPrefs.HasKey(spName) && (FileBasedPrefs.GetString(spName) == "showed_once"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            if (GetComponent<BoxCollider>() != null && initialEnableBoxCollider)
                GetComponent<BoxCollider>().enabled = false;
            else if (GetComponent<BoxCollider>() != null && !initialEnableBoxCollider)
                GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            if (GetComponent<BoxCollider>() != null && initialEnableBoxCollider)
                GetComponent<BoxCollider>().enabled = true;
            else if (GetComponent<BoxCollider>() != null && !initialEnableBoxCollider)
                GetComponent<BoxCollider>().enabled = false;
        }
    }


}
