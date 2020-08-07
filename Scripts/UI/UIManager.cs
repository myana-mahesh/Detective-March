using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;
    public MainMenuScreen mainMenu;
    public GamePlayScreen gamePlay;
    public SettingsScreen settingScreen;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
}
