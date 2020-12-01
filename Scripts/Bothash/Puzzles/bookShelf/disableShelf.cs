using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableShelf : MonoBehaviour
{
    public GameObject examine;
    public GameObject[] objects;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
