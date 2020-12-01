using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using UnityEngine.SceneManagement;
using Steamworks;

public class Restrat : MonoBehaviour
{   
    /* public GameObject mainScreen;
    
    public GameObject demoScene; */
    public GameObject[] managers;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
       
        //mainScreen.SetActive(true);
        
        

        //SteamUserStats.ResetAllStats(true);

        FileBasedPrefs.DeleteAll();

        foreach(string achname in bothash.AlbumManager.Instance.albumSO.ACHNAMES)
        {
            FileBasedPrefs.SetInt(achname, 1);
        }

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

        
        //FileBasedPrefs.SetInt("_restarted_",1);
        SceneManager.LoadScene(0);
    }
}
