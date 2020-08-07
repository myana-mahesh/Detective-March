using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCasketDown : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject[] character;
    public DIalogue Dialogues;
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnMouseDown () {
        if (PlayerPrefs.HasKey ("SilverKeyfound") && !PlayerPrefs.HasKey ("BenardEntryDone")) {
            PlayerPrefs.SetInt ("BenardEntryDone", 1);
            bothash.DialogueM.Instance.sentence = Dialogues.sentences;
            bothash.DialogueM.Instance.Avatar = character;
            bothash.DialogueM.Instance.Audio = Dialogues.Audios;
            bothash.DialogueM.Instance.startDialogue ();
        }
    }
}