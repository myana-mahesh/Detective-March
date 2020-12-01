using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretDoorManager : MonoBehaviour
{
    public GameObject examine;
    public GameObject navigate;
    public List<GameObject> keys=new List<GameObject>();
    public GameObject prize;
    public GameObject currRoom;
    public GameObject[] character;
    public DIalogue Dialogues;
    List<GameObject> keysDuplicate=new List<GameObject>();
    int count;
    public static secretDoorManager Instance{get;private set;}


    public string SteamACH = "Puzzle Master";
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
        count=0;
        foreach (GameObject item in keys)
        {
            keysDuplicate.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void removeKey(GameObject pressedKey){
        pressedKey.GetComponent<SpriteRenderer>().enabled=true;
        SoundManager.Instance.gameSounds[13].Play();
        if(!keys.Contains(pressedKey)){
            keys.Clear();
            keys.AddRange(keysDuplicate);
            count=0;
            foreach (GameObject item in keysDuplicate)
            {
                item.GetComponent<SpriteRenderer>().enabled=false;
            }
            pressedKey.GetComponent<SpriteRenderer>().enabled=false;
        }
        else{
            count++;
            keys.Remove(pressedKey);
            if(count>=8){
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



                examine.SetActive(false);
                navigate.SetActive(true);
                bothash.DialogueM.Instance.sentence = Dialogues.sentences;
                bothash.DialogueM.Instance.Avatar = character;
                bothash.DialogueM.Instance.Audio = Dialogues.Audios;
                bothash.DialogueM.Instance.startDialogue ();
                currRoom.SetActive(false);
            }
        }
        
    }
}
