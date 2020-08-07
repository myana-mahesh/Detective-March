using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    public AudioSource[] gameMusics;
    public AudioSource[] gameSounds;

    public int Sound = 1;
    public int Music = 1;
    /*
    -------SOUNDS-------
    0 - step
    1 - lose
    2 - buttonclick
    3 - win
    4 - player takes kill
    5 - goal
    6 - 4 or 8 Roll
    7 - player gets killed
    8 - dice roll
    */

    private void Awake()
    {
        Instance = this;
        if (PlayerPrefs.HasKey("sound"))
        {
            Sound = PlayerPrefs.GetInt("sound");
            SoundsOnOff();
        }

        if (PlayerPrefs.HasKey("music"))
        {
            Music = PlayerPrefs.GetInt("music");
            MusicsOnOff();
        }
    }

    public void SoundsOnOff()
    {
        for(int i=0;i< gameSounds.Length; i++)
        {
            gameSounds[i].volume = Sound;
        }
    }
    


    public void MusicsOnOff()
    {
        for (int i = 0; i < gameMusics.Length; i++)
        {
            gameMusics[i].volume = Music;
        }
    }
    

    public void OnClickButton_Sound()
    {
        gameSounds[0].Play();
    }

}
