using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableWordPuzz : MonoBehaviour
{
    
    public GameObject[] examine;
    public GameObject albumReff;
    
    
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
        if(albumReff.activeSelf){
            foreach (GameObject item in examine)
            {
                item.SetActive(false);
            }
            
        }
    }
}
