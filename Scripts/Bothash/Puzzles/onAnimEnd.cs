using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAnimEnd : MonoBehaviour
{
    public bool haveDailogues;
    public GameObject[] character;
    public DIalogue Dialogues;
    // Start is called before the first frame update
    
    public GameObject objToShow;

    [Header("IF WANT TO HIDE SOMETHING ELSE")]
    public bool hideElse = false;

    public GameObject hidethis;

    public bool hideMultiple;
    public GameObject[] multipleObjects;


    public bool isSteamACH = false;
    public string SteamACH = "Happy Ending";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAnimEndFn()
    {
        
        if(hideMultiple){
            foreach (GameObject item in multipleObjects)
            {
                item.SetActive(false);
            }
            
        }
        if(haveDailogues){
            bothash.DialogueM.Instance.sentence = Dialogues.sentences;
            bothash.DialogueM.Instance.Avatar = character;
            bothash.DialogueM.Instance.Audio = Dialogues.Audios;
            bothash.DialogueM.Instance.startDialogue ();
            Debug.Log("da");
            }
        
        if (hideElse)
        {
            hidethis.SetActive(false);
            Debug.Log("hide");
        }
        if (objToShow)
        {
            objToShow.SetActive(true);
            
        }

        if (isSteamACH)
        {

            SteamHandler.instance.SetAch(SteamACH);
        }
        
    }
    
}
