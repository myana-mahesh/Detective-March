using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {
    public bool isClickable;
    public GameObject albumRefference;
    public bool haveDilaogues;
    public GameObject[] character;
    public string[] sentences;
    public AudioClip[] Audios;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    public void startClickDialogues () {
        bothash.DialogueM.Instance.sentence = sentences;
        bothash.DialogueM.Instance.Avatar = character;
        bothash.DialogueM.Instance.Audio = Audios;
        bothash.DialogueM.Instance.startDialogue ();
    }
    
}