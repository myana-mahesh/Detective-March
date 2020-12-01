using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnlyOnce : MonoBehaviour
{

    public GameObject item;
    //	public GameObject blockScreen;


    public void Start()
    {
        //		blockScreen.SetActive(true);
        if (item == null)
            item = gameObject;
        Invoke("ItemDisplay", 0);
    }

    public void ItemDisplay()
    {
        // todo save hog 
        if (item != null)
        {
            if (FileBasedPrefs.HasKey(item.name))
            {
                item.SetActive(false);
            }
        }
    }


    private void OnMouseDown()
    {
        if (item != null)
        {
            if (!FileBasedPrefs.HasKey(item.name))
            {
                FileBasedPrefs.SetString(item.name, "hidden_once");
                item.SetActive(false);
            }
        }
    }

    public void ButtonHideMe()
    {
        if (item != null)
        {
            if (!FileBasedPrefs.HasKey(item.name))
            {
                FileBasedPrefs.SetString(item.name, "hidden_once");
                item.SetActive(false);
            }
        }
    }
}
