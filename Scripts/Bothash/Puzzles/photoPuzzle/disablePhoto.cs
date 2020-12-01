using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablePhoto : MonoBehaviour
{
    public bool waitForPhoto;
    public GameObject[] examine;
    public GameObject albumReff;
    
    public static disablePhoto Instance{get;set;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check();
    }
    void check(){
        if(waitForPhoto){
         if( albumReff.activeSelf && FileBasedPrefs.HasKey("photoPuzzCompleted")){
            foreach (GameObject item in examine)
            {
                item.SetActive(false);
            }
            }
        }
        else if(FileBasedPrefs.HasKey("photoPuzzCompleted")){
            foreach (GameObject item in examine)
            {
                item.SetActive(false);
            }
        }
    }

}
