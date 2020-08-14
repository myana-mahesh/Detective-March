﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableJigsaw : MonoBehaviour
{
    public bool stopForPhoto;
    public GameObject albumRefernce;
    public GameObject[] examineList;
    public bool rewardCollected;
    public static disableJigsaw Instance { get; private set; }
    void Awake () 
    {
        if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad (gameObject);
            } 
        else {
            Destroy (gameObject);
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
    public void check(){
        if(stopForPhoto){
            if (albumRefernce.activeSelf && rewardCollected)
            {
                foreach (GameObject item in examineList)
                {
                    item.SetActive(false);
                }
            }
        }
        else
        {
            foreach (GameObject item in examineList){
                item.SetActive(false);
            }    
        } 
    }
}
