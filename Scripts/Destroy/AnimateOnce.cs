using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimateOnce : MonoBehaviour
{
    public GameObject objectToHide;
    
    public void OnEnable()
    {
        PlayVent();
    }

    
    public void PlayVent()
    {
        if (FileBasedPrefs.HasKey(this.gameObject.name))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            return;
        }
        else
        {
            FileBasedPrefs.SetString(this.gameObject.name, "Done");
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
    public void HideObject(){
        objectToHide.SetActive(false);
    }
}
