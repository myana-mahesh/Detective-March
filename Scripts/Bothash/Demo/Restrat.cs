using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using UnityEngine.SceneManagement; 

public class Restrat : MonoBehaviour
{   public GameObject Rooms;
    public GameObject mainScreen;
    public GameObject grounFloor;
    public GameObject[] allRooms;
    public GameObject[] managers;
    public ObjectSavingSo objectSaving;
    public bothash.PlayerWholeInventory InventorySO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
       
        mainScreen.SetActive(true);
        PlayerPrefs.DeleteAll();
        
        foreach (GameObject manager in managers)
        {
           Destroy(manager);
        } 

        if (Directory.Exists(Application.persistentDataPath + "/GameData"))  
        {  
            Directory.Delete(Application.persistentDataPath + "/GameData",true);  
        }

        if (Directory.Exists(Application.persistentDataPath + "/Inventory"))  
        {  
            Directory.Delete(Application.persistentDataPath + "/Inventory",true);  
        }

        if (Directory.Exists(Application.persistentDataPath + "/PuzzlesData"))  
        {  
            Directory.Delete(Application.persistentDataPath + "/PuzzlesData",true);  
        }
        if (Directory.Exists(Application.persistentDataPath + "/AlbumData"))  
        {  
            Directory.Delete(Application.persistentDataPath + "/AlbumData",true);  
        }

        PlayerPrefs.SetInt("restarted",1);
           
    }
}
