using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public bool iAmAlbum = false;
    public bool hasBlocker;
    public GameObject blocker;

    void OnEnable()
    {   if(!hasBlocker  ){
        SoundManager.Instance.PlayMyMusic(this.gameObject.tag);
        }
        else if(hasBlocker && !blocker.activeSelf){
            SoundManager.Instance.PlayMyMusic("Puzzle");
        }
        else
        {
            SoundManager.Instance.PlayMyMusic("Game");
        }
    }

    void OnDisable()
    {
        if (iAmAlbum) {
            SoundManager.Instance.StopAlbum();
            }
        
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
