using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableChef : MonoBehaviour
{
    public bool stopForPhoto;
    public GameObject albumRefernce;
    public GameObject[] examineList;
    
   
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
            if (albumRefernce.activeSelf && FileBasedPrefs.HasKey("chefClicked"))
            {
                foreach (GameObject item in examineList)
                {
                    item.SetActive(false);
                }
            }
        }
        else if(FileBasedPrefs.HasKey("chefClicked"))
        {
            foreach (GameObject item in examineList){
                item.SetActive(false);
            }    
        } 
    }
}
