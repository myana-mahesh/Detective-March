using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene : MonoBehaviour
{  
    public GameObject[] managers;

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
        bothash.AlbumManager.Instance.Save();
        bothash.InventoryManager.instance.saveToDB();
        FirstFloorSave.Instance.Save();
        foreach (GameObject manager in managers)
        {
           Destroy(manager);
        }
        if(!FileBasedPrefs.HasKey("inGameSceneChange")){
            FileBasedPrefs.SetInt("inGameSceneChange",1);
        }
        if(!FileBasedPrefs.HasKey("showStairCase")){
            FileBasedPrefs.SetInt("showStairCase",1);
        }
        FileBasedPrefs.SetInt("CurrentScene", 1);
        SceneManager.LoadScene(0);
    }
}
