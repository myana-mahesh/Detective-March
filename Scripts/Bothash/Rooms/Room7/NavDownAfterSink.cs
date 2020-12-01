using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDownAfterSink : MonoBehaviour {
    public GameObject[] character;
    public string[] sentences;
    public AudioClip[] Audios;
    public GameObject nextRoom;
    public GameObject currRoom;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    void OnMouseDown () {
        if (!FileBasedPrefs.HasKey ("afterSink") && FileBasedPrefs.HasKey ("clickedTaps")) {
            Debug.Log ("downClicked");
            FileBasedPrefs.SetInt ("afterSink", 1);
            bothash.DialogueM.Instance.sentence = sentences;
            bothash.DialogueM.Instance.Avatar = character;
            bothash.DialogueM.Instance.Audio = Audios;
            currRoom.SetActive (false);
            nextRoom.SetActive (true);
            bothash.DialogueM.Instance.startDialogue ();
        } else {
            currRoom.SetActive (false);
            nextRoom.SetActive (true);
        }

    }
}