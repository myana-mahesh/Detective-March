using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disaleCabinet : MonoBehaviour
{
    
    public GameObject examine;
    public GameObject[] objects;
    
    public static disaleCabinet Instance{get;set;}
    void Awake () 
    {
        if (Instance == null) {
                Instance = this;
                //DontDestroyOnLoad (gameObject);
            } 
        else {
            Destroy (gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDisable()
    {
        if(check()){
            examine.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(check()){
            examine.SetActive(false);
        }
    }
    bool check(){
        foreach (GameObject item in objects)
        {
            if(item.activeSelf)
            return false;
        }
        return true;
    }}
