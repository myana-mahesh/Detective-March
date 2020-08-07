using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimateOnceClicked : MonoBehaviour
{
    public void Start()
    {
        if (GetComponent<Animator>() != null)
            gameObject.GetComponent<Animator>().enabled = false;
        Invoke("PlayVent", 0);
    }

    public void PlayVent()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetString(gameObject.name, "showed_once");
                if (GetComponent<Animator>() != null)
                    GetComponent<Animator>().enabled = true;
                Debug.LogError("Destroy obj");
                //gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        PlayVent();
    }
}
