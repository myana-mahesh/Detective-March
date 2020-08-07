using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePickUpCursor : MonoBehaviour
{

//    public GameObject myPopupScreen;

    void Start()
    {
    }

    void OnMouseEnter()
    {
        MousePointer.Instance.SetPickUpPointer();
    }

    void OnMouseDown()
    {
        //		SoundManager.Instance.gameSounds[35].Play();

        //DEV_CODE || ADDING NULL CONDITION
        MousePointer.Instance.SetNormalPointer();
//        if (myPopupScreen) myPopupScreen.SetActive(true);
    }

    void OnMouseExit()
    {
        MousePointer.Instance.SetNormalPointer();
    }
}
