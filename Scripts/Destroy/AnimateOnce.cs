using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimateOnce : MonoBehaviour
{
    public void OnEnable()
    {
        PlayVent();
    }

    
    public void PlayVent()
    {
        if (PlayerPrefs.HasKey(this.gameObject.name))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            return;
        }
        else
        {
            PlayerPrefs.SetString(this.gameObject.name, "Done");
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
