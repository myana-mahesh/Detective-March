using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableSafePuzz : MonoBehaviour
{
    public GameObject examine;
    public GameObject[] objects;
    public GameObject albumReff;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDisable()
    {
        if(check() && albumReff.activeSelf){
            examine.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(check() && albumReff.activeSelf){
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
