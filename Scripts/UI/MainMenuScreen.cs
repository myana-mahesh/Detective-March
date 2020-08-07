using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    public GameObject allRooms;
    public void Start()
    {
        //OnClick_Play();
        Debug.Log("Start");
        if (PlayerPrefs.GetInt("ComingFromRestart") == 1)
        {
            UIManager.Instance.mainMenu.gameObject.SetActive(false);
            // Invoke("DisableMenu",0.5f);
            allRooms.SetActive(true);
            PlayerPrefs.SetInt("ComingFromRestart", 0);

        }
        SoundManager.Instance.gameMusics[0].Play();
    }


    public void OnClick_Play()
    {

        UIManager.Instance.mainMenu.gameObject.SetActive(false);

    }

    public void OnClick_QuitButton()
    {
        // PlayerPrefs.SetInt("ComingFromRestart", 0);
        Application.Quit();
    }

    void DisableMenu()
    {
        allRooms.SetActive(true);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("ComingFromRestart", 0);
    }
}
