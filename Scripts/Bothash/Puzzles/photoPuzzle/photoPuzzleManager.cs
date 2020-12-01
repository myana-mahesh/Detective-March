using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoPuzzleManager : MonoBehaviour
{   
    public GameObject prize;
    private GameObject first;
    private GameObject second;
    public int counter;
    public GameObject block;
    bool firstPassed;


    public string SteamACH = "Puzzle Master";
    public static photoPuzzleManager Instance { get; private set; }
    
    void Awake () {
        if (Instance == null) {
            Instance = this;
                //DontDestroyOnLoad (gameObject);
        } else {
            Destroy (gameObject);
        }
    }    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void passData(GameObject objToPass){
        if (!firstPassed) {
            first = objToPass;
            firstPassed = true;
            //first.GetComponent<SpriteRenderer>().enabled = true;
            //first.SetActive(false);
            SoundManager.Instance.gameSounds[6].Play();
        } else if(first.GetComponent<SpriteRenderer>().sprite.name!=objToPass.GetComponent<SpriteRenderer>().sprite.name){
            second = objToPass;
            firstPassed = false;
            //second.GetComponent<SpriteRenderer>().enabled = true;
            SoundManager.Instance.gameSounds[6].Play();
            Vector3 temp=first.transform.position;
            first.transform.position=second.transform.position;
            second.transform.position=temp;
            first.GetComponent<photo>().check();
            second.GetComponent<photo>().check();
            if(counter==11){
                prize.SetActive(true);
                if (FileBasedPrefs.HasKey("bigPuzzCount"))
                {
                    FileBasedPrefs.SetInt("bigPuzzCount", FileBasedPrefs.GetInt("bigPuzzCount") + 1);
                }
                else
                {
                    FileBasedPrefs.SetInt("bigPuzzCount", 1);
                }
                Debug.Log(FileBasedPrefs.GetInt("bigPuzzCount"));
                if (FileBasedPrefs.GetInt("bigPuzzCount") >= 8)
                {
                    SteamHandler.instance.SetAch(SteamACH);
                }




                block.SetActive(false);
            }
        }
    }
 
}
