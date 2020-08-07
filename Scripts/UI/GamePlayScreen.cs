using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreen : MonoBehaviour {

   public GameObject PauseScreen;

    public void OnClick_PauseButton()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
    }

    public void OnClick_ResumeGame()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }
    public void OnClick_EndGame()
    {
        Debug.Log("end game...");

//        GameControl.Instance.StopAllCoroutines();

        Time.timeScale = 1;

        PauseScreen.SetActive(false);
        UIManager.Instance.gamePlay.gameObject.SetActive(false);
        UIManager.Instance.mainMenu.gameObject.SetActive(true);
    }
}
