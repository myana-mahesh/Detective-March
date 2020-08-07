using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateAreaExamineCursor : MonoBehaviour
{

    /* MousePointer myPointer; */

    public GameObject myPopupScreen;

    void Start()
    {

        /* myPointer = GameObject.FindGameObjectWithTag("Main").GetComponent<MousePointer>(); */
    }

    void OnMouseEnter()
    {
        MousePointer.Instance.SetExaminePointer();
    }

    void OnMouseDown()
    {
        //		SoundManager.Instance.gameSounds[35].Play();
        myPopupScreen.SetActive(true);
    }

    void OnMouseExit()
    {
        MousePointer.Instance.SetNormalPointer();
    }
}
