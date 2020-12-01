using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorPuzzleManager : MonoBehaviour
{
    public GameObject[] correctPieces;
    public GameObject[] wrongPeices;
    public GameObject cabinet;
    public GameObject examineCabinet;
    public GameObject examineMirror;

    public string SteamACH = "Puzzle Master";
    public string SteamACH1 = "Symmetry";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(puzzleDone()){
           cabinet.SetActive(true);

            SteamHandler.instance.SetAch(SteamACH1);

            




            examineCabinet.SetActive(false);
           examineMirror.SetActive(false);
           if(!FileBasedPrefs.HasKey("soundPlayed")){
               FileBasedPrefs.SetInt("soundPlayed",1);
                SoundManager.Instance.gameSounds[9].Play();
           }
           Debug.Log("done");
       } 
    }
    bool puzzleDone(){
        foreach (GameObject item in correctPieces)
        {
            if(! item.activeSelf){
                return false;
            }
        }
        
        return true;
    }
    private void OnDisable()
    {
        if(!puzzleDone()){
            foreach (GameObject item in correctPieces)
            {
                item.SetActive(false);

            }
            foreach (GameObject item in wrongPeices)
            {
                item.SetActive(true);                
            }
        }
    }

}
