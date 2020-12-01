using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour {
    public bool haveDialogues;
    public GameObject[] character;
    public DIalogue Dialogues;
    public bool hasAudio;

    public bool positionHold;
    public Vector3 holdPosition;
    private void Update () {
        /* if (FileBasedPrefs.HasKey ("pillowAnime")) {
            gameObject.GetComponent<Animator> ().enabled = false;
*/

    }

    void OnEnable()
    {
        if(FileBasedPrefs.HasKey(this.gameObject.name + "anime") && positionHold)
        {
            this.gameObject.transform.localPosition = holdPosition;
        }
    }
    
    private void OnMouseDown () {
        
        if(this.gameObject.name=="Cover"){
            gameObject.GetComponent<Animator>().enabled=true;
            StartCoroutine(waitFor1());
        }
        else if (!FileBasedPrefs.HasKey (this.gameObject.name+"anime")) {
            gameObject.GetComponent<Animator> ().enabled = true;
            if(hasAudio){
                gameObject.GetComponent<AudioSource>().enabled=true;
            }
            FileBasedPrefs.SetInt (this.gameObject.name+"anime", 1);
            StartCoroutine (waitFor1 ());

            //gameObject.GetComponent<Animator> ().enabled = false;
        }

    }
    IEnumerator waitFor1 () {
        yield return new WaitForSeconds (1);
        gameObject.GetComponent<Animator> ().enabled = false;
        if(hasAudio){
                gameObject.GetComponent<AudioSource>().enabled=false;
            }
        if(haveDialogues){
            bothash.DialogueM.Instance.sentence = Dialogues.sentences;
            bothash.DialogueM.Instance.Avatar = character;
            bothash.DialogueM.Instance.Audio = Dialogues.Audios;
            bothash.DialogueM.Instance.startDialogue ();
        }
    }
}