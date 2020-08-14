using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableSink : MonoBehaviour
{
    public bool stopForPhoto;
    public GameObject albumRefernce;
    public GameObject[] examineList;
    
    public static disableSink Instance { get; private set; }
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
        check();
    }
    public void check(){
        if(stopForPhoto){
            if (albumRefernce.activeSelf && PlayerPrefs.HasKey("scribbleClicked"))
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
