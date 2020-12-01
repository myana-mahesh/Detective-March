using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableDrawer : MonoBehaviour
{
    public GameObject examine;
    public GameObject[] albumReff;
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
        foreach (GameObject item in albumReff)
        {
            if(!item.activeSelf){
                return false;
            }
        }
        return true;
    }
}
