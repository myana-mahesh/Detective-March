using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    public AudioSource[] gameMusics;
    public AudioSource[] gameSounds;
    public AudioSource DialogueSound;

    

    public int Sound = 1;
    public int Music = 1;

    public int myMusic ;

    public int puzzleMusic = 2;

    public int album = 4;

    bool _puzzlePlaying = false;
    bool _gamePlaying = false;
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
        if (FileBasedPrefs.HasKey("sound"))
        {
            Sound = FileBasedPrefs.GetInt("sound");
            SoundsOnOff();
        }

        if (FileBasedPrefs.HasKey("music"))
        {
            Music = FileBasedPrefs.GetInt("music");
            MusicsOnOff();
        }

        //gameMusics[Music].Play();
        
    }

    public void SoundsOnOff()
    {
        for(int i=0;i< gameSounds.Length; i++)
        {
            gameSounds[i].volume = Sound;
        }
        DialogueSound.volume=Sound;
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

    public void PlayMyMusic(string typeName)
    {
        Debug.LogFormat("Sound for {0}", typeName);
        switch (typeName)
        {
            case "Puzzle":
                gameMusics[album].Stop();
                gameMusics[myMusic].Stop();
                if(!_puzzlePlaying)
                gameMusics[puzzleMusic].Play();
                _puzzlePlaying = true;
                _gamePlaying = false;
                break;
            case "Game":
            Debug.Log("inside GAme *******");
                gameMusics[album].Stop();
                gameMusics[puzzleMusic].Stop();
                if(!_gamePlaying){
                    Debug.Log("inside if******");
                gameMusics[myMusic].Play();}
                _gamePlaying = true;
                _puzzlePlaying = false;
                break;
            case "Album":
                gameMusics[puzzleMusic].Stop();
                gameMusics[myMusic].Stop();
                gameMusics[album].Play();
                //_puzzlePlaying = false;
                //_gamePlaying = false;
                break;
        }
    }

    public void StopAlbum()
    {
        gameMusics[album].Stop();
        if (_gamePlaying) {
            gameMusics[myMusic].Play();
            _puzzlePlaying = false;
            //_gamePlaying = false;
        }
        else if (_puzzlePlaying)
        {
            gameMusics[puzzleMusic].Play();
            //_puzzlePlaying = false;
            _gamePlaying = false;
        }


    }

}
