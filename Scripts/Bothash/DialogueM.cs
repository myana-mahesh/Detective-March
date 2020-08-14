using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace bothash {
    public class DialogueM : MonoBehaviour {
        public AudioSource Asource;
        public string[] sentence;
        public GameObject[] Avatar;
        public AudioClip[] Audio;
        [SerializeField]
        private Text DialogueBox;
        [SerializeField]
        private GameObject DialogueParent;
        public GameObject BlockScreen;
        public GameObject CabinetKey;
        public GameObject PP3;
        [SerializeField]
        private float typingSpeed = 0.125f;

        private Coroutine _co;
        int i, j;
        // Start is called before the first frame update

        public static DialogueM Instance { get; private set; }

        void Awake () {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad (gameObject);
            } else {
                Destroy (gameObject);
            }
        }
        void Start () {

        }

        IEnumerator PlayText(string story)
        {
            foreach (char c in story)
            {
                DialogueBox.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        private void TypingEffect(string text)
        {
            DialogueBox.text = "";
            if(_co!=null)
                StopCoroutine(_co);
            
            _co =  StartCoroutine("PlayText", text);

        }
        public void startDialogue () {
            i = 0;
            //DialogueBox.text = sentence[0];
            TypingEffect(sentence[0]);
            Avatar[0].SetActive (true);
            Asource.clip = Audio[0];
            Asource.Play ();
            DialogueParent.SetActive (true);
            BlockScreen.SetActive (true);
        }
        public void NextDialogue () {
            ++i;
            j = i - 1;
            if (i < sentence.Length) {
                //DialogueBox.text = sentence[i];
                TypingEffect(sentence[i]);
                Avatar[j].SetActive (false);
                Avatar[i].SetActive (true);
                Asource.Stop ();
                Asource.clip = Audio[i];
                Asource.Play ();
                /* Audio[j].Stop();
                Audio[i].Play(); */

            } else {
                if (PlayerPrefs.HasKey ("clickedTaps") && PlayerPrefs.HasKey ("afterSink")) {
                    CabinetKey.SetActive (true);
                    PlayerPrefs.DeleteKey ("clickedTaps");
                    PlayerPrefs.DeleteKey ("afterSink");
                    PlayerPrefs.SetInt ("keyDisplayed", 1);

                }
                if (PlayerPrefs.HasKey ("PantingSolved") && PlayerPrefs.HasKey ("PantingSolvedNavigationDone")) {
                    PP3.SetActive (true);
                    PlayerPrefs.DeleteKey ("PantingSolved");
                    PlayerPrefs.DeleteKey ("PantingSolvedNavigationDone");
                    PlayerPrefs.SetInt ("paintigOjectsPicked", 1);

                }
                Asource.Stop();
                Asource.clip=null;
                Avatar[j].SetActive (false);
                DialogueParent.SetActive (false);
                BlockScreen.SetActive (false);
            }
        }
    }

}