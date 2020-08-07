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
        item.SetActive(true);
        hideItem.SetActive(false);
    }

}
