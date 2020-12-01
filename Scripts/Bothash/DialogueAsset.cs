using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace bothash {
    public class DialogueAsset : MonoBehaviour {
        public bool isMandatory;
        public bool onloadDialogue;
        public string status;
        public GameObject[] character;
        public DIalogue Dialogues;
        public DIalogue blockDialogues;
        public GameObject blockscreen;

        public GameObject[] blockAvatar;
        public enum statusCheck {
            readOnly,
            Pickup,
        }

        void Start () {
            if (onloadDialogue) {
                /* if (FileBasedPrefs.GetInt (this.gameObject.name) != 1) {
                    DialogueM.Instance.sentence = Dialogues.sentences;
                    DialogueM.Instance.Avatar = character;
                    DialogueM.Instance.Audio = Dialogues.Audios;
                    DialogueM.Instance.startDialogue ();
                } else {
                    if (FileBasedPrefs.GetInt (this.gameObject.name, 5) == 5) {
                        FileBasedPrefs.SetInt (this.gameObject.name, 1);
                        DialogueM.Instance.sentence = Dialogues.sentences;
                        DialogueM.Instance.Avatar = character;
                        DialogueM.Instance.Audio = Dialogues.Audios;
                        DialogueM.Instance.startDialogue ();
                    } else {
                        return;
                    }
                } */
                if(this.gameObject.name=="Kitchen"){
                    
                    StartCoroutine(waitForchair());
                }
                else if(this.gameObject.name=="Room31"){
                    StartCoroutine(waitForComputer());
                }
                else if(this.gameObject.name=="DarkLivingRoom"){
                    StartCoroutine(waitForAnim());
                }
                
                else if(!FileBasedPrefs.HasKey (this.gameObject.name) ) {
                    FileBasedPrefs.SetInt (this.gameObject.name, 1);
                    DialogueM.Instance.sentence = Dialogues.sentences;
                    DialogueM.Instance.Avatar = character;
                    DialogueM.Instance.Audio = Dialogues.Audios;
                    DialogueM.Instance.startDialogue ();
                }
                
                

            }
        }

        // Update is called once per frame
        void Update () {

        }
        private void OnMouseDown () {
            if (isMandatory) {

                DedicatedRoomManager.RInstance.RemoveItemHit (this.gameObject);
            }
            if (!onloadDialogue) {
                
                DialogueM.Instance.sentence = Dialogues.sentences;
                DialogueM.Instance.Avatar = character;
                DialogueM.Instance.Audio = Dialogues.Audios;
                DialogueM.Instance.startDialogue ();
            }

        }
        IEnumerator waitForchair(){
            
            if (!FileBasedPrefs.HasKey (this.gameObject.name)) {
                    FileBasedPrefs.SetInt (this.gameObject.name, 1);
                    blockscreen.SetActive(true);
                    yield return new WaitForSeconds(2.2f);
                    DialogueM.Instance.sentence = Dialogues.sentences;
                    DialogueM.Instance.Avatar = character;
                    DialogueM.Instance.Audio = Dialogues.Audios;
                    DialogueM.Instance.startDialogue ();
                }
        }

        IEnumerator waitForComputer(){
            
            if (!FileBasedPrefs.HasKey (this.gameObject.name)) {
                    FileBasedPrefs.SetInt (this.gameObject.name, 1);
                    //blockscreen.SetActive(true);
                    yield return new WaitForSeconds(9.2f);
                    DialogueM.Instance.sentence = Dialogues.sentences;
                    DialogueM.Instance.Avatar = character;
                    DialogueM.Instance.Audio = Dialogues.Audios;
                    DialogueM.Instance.startDialogue ();
                }
        }

        IEnumerator waitForAnim(){
            
            if (!FileBasedPrefs.HasKey (this.gameObject.name)) {
                    FileBasedPrefs.SetInt (this.gameObject.name, 1);
                    //blockscreen.SetActive(true);
                    yield return new WaitForSeconds(2.2f);
                    DialogueM.Instance.sentence = Dialogues.sentences;
                    DialogueM.Instance.Avatar = character;
                    DialogueM.Instance.Audio = Dialogues.Audios;
                    DialogueM.Instance.startDialogue ();
                }
        }
    }
}