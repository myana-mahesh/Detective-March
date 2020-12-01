using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableMultiple : MonoBehaviour
{
    public GameObject[] reward;
    public GameObject[] examine; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfPicked())
        {
            foreach (GameObject item in examine)
            {
                item.SetActive(false);
            }
            
        }
    }
    bool checkIfPicked(){
        foreach (GameObject item in reward)
        {
            if(item.activeSelf){
                return false;
            }
        }
        return true;
    }
}
