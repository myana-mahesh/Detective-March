using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadAfterRestart : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startManagers()
    {   if (PlayerPrefs.HasKey("restarted"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("GroundFloor");
            PlayerPrefs.DeleteKey("restarted");
        }
         
    } 
}

