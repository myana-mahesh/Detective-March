using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAndAlbum : MonoBehaviour
{
    public GameObject item;
    public GameObject hideItem;
    public GameObject item2;


    
    private void OnMouseDown()
    {
        item.SetActive(true);
        item2.SetActive(true);
        hideItem.SetActive(false);
    }


}
