using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showGrandapaRoom : MonoBehaviour
{
    public GameObject[] Rooms;
    private void Awake()
    {   if(FileBasedPrefs.HasKey("chimneyNav")){
            FileBasedPrefs.DeleteKey("chimneyKey");
            foreach (GameObject Room in Rooms)
            {
                if(Room.name=="Room29")
                    Room.SetActive(true);
                else
                {
                Room.SetActive(false);
                }
            }
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

}
