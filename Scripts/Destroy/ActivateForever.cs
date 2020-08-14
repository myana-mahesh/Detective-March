using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateForever : MonoBehaviour
{

    public GameObject item;
    public GameObject hideItem;
    //	public GameObject blockScreen;


    
    private void OnMouseDown()
    {
        SoundManager.Instance.gameSounds[0].Play();
        item.SetActive(true);
        hideItem.SetActive(false);
    }

}
