using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    public GameObject allRooms;
    private void Awake()
    {
        if (FileBasedPrefs.HasKey("inGameSceneChange"))
        {
            gameObject.SetActive(false);
            FileBasedPrefs.DeleteKey("inGameSceneChange");
        }
    }
    public void Start()
    {
        //OnClick_Play();
        Debug.Log("Start");
        if (FileBasedPrefs.GetInt("ComingFromRestart") == 1)
        {
            UIManager.Instance.mainMenu.gameObject.SetActive(false);
            // Invoke("DisableMenu",0.5f);
            allRooms.SetActive(true);
            FileBasedPrefs.SetInt("ComingFromRestart", 0);

        }
        //SoundManager.Instance.gameMusics[0].Play();
    }


    public void OnClick_Play()
    {

        UIManager.Instance.mainMenu.gameObject.SetActive(false);

    }

    public void OnClick_QuitButton()
    {
        // FileBasedPrefs.SetInt("ComingFromRestart", 0);
        Application.Quit();
    }

    void DisableMenu()
    {
        allRooms.SetActive(true);
    }
    private void OnApplicationQuit()
    {
        FileBasedPrefs.SetInt("ComingFromRestart", 0);
    }
}
