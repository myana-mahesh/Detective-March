using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDownAfterSolving : MonoBehaviour {
    public GameObject[] character;
    public string[] sentences;
    public AudioClip[] Audios;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnMouseDown () {
        if (FileBasedPrefs.HasKey ("PantingSolved") && !FileBasedPrefs.HasKey ("PantingSolvedNavigationDone")) {
            FileBasedPrefs.SetInt ("PantingSolvedNavigationDone", 1);
            bothash.DialogueM.Instance.sentence = sentences;
            bothash.DialogueM.Instance.Avatar = character;
            bothash.DialogueM.Instance.Audio = Audios;
            bothash.DialogueM.Instance.startDialogue ();
        }
    }
}