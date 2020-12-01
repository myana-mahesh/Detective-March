using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene1 : MonoBehaviour
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
        GroundFloorSave.Instance.Save();
        foreach (GameObject manager in managers)
        {
           Destroy(manager);
        } 
        if(!FileBasedPrefs.HasKey("inGameSceneChange")){
            FileBasedPrefs.SetInt("inGameSceneChange",1);
            Debug.Log("***** FileBasedPrefset ****");
        }
        if (this.gameObject.name=="chimneyNav" && !FileBasedPrefs.HasKey("chimneyNav")) {
            FileBasedPrefs.SetInt(this.gameObject.name,1);
        }
        FileBasedPrefs.SetInt("CurrentScene", 2);
        SceneManager.LoadScene(0);
        
    }
}
