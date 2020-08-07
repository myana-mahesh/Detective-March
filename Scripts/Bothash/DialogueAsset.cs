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

        public GameObject[] blockAvatar;
        public enum statusCheck {
            readOnly,
            Pickup,
        }

        void Start () {
            if (onloadDialogue) {
                /* if (PlayerPrefs.GetInt (this.gameObject.name) != 1) {
                    DialogueM.Instance.sentence = Dialogues.sentences;
                    DialogueM.Instance.Avatar = character;
                    DialogueM.Instance.Audio = Dialogues.Audios;
                    DialogueM.Instance.startDialogue ();
                } else {
                    if (PlayerPrefs.GetInt (this.gameObject.name, 5) == 5) {
                        PlayerPrefs.SetInt (this.gameObject.name, 1);
                        DialogueM.Instance.sentence = Dialogues.sentences;
                        DialogueM.Instance.Avatar = character;
                        DialogueM.Instance.Audio = Dialogues.Audios;
                        DialogueM.Instance.startDialogue ();
                    } else {
                        return;
                    }
                } */
                if (!PlayerPrefs.HasKey (this.gameObject.name)) {
                    PlayerPrefs.SetInt (this.gameObject.name, 1);
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
    }
}