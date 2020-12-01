using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterTree : MonoBehaviour
{
    public GameObject[] character;
    public DIalogue Dialogues;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(FileBasedPrefs.HasKey("plantInspected") && !FileBasedPrefs.HasKey("compass")){
            FileBasedPrefs.SetInt("compass",1);
            bothash.DialogueM.Instance.sentence = Dialogues.sentences;
            bothash.DialogueM.Instance.Avatar = character;
            bothash.DialogueM.Instance.Audio = Dialogues.Audios;
            bothash.DialogueM.Instance.startDialogue ();
        }
    }
}
