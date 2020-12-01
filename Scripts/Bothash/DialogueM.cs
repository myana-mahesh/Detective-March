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
        public GameObject compass;
        public GameObject knob;
        [SerializeField]
        private float typingSpeed = 0.125f;
        public GameObject march; 
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
                if (FileBasedPrefs.HasKey ("clickedTaps") && FileBasedPrefs.HasKey ("afterSink")) {
                    CabinetKey.SetActive (true);
                    FileBasedPrefs.DeleteKey ("clickedTaps");
                    FileBasedPrefs.DeleteKey ("afterSink");
                    FileBasedPrefs.SetInt ("keyDisplayed", 1);

                }
                else if (FileBasedPrefs.HasKey ("PantingSolved") && FileBasedPrefs.HasKey ("PantingSolvedNavigationDone")) {
                    PP3.SetActive (true);
                    FileBasedPrefs.DeleteKey ("PantingSolved");
                    FileBasedPrefs.DeleteKey ("PantingSolvedNavigationDone");
                    FileBasedPrefs.SetInt ("paintigOjectsPicked", 1);

                }
                else if (FileBasedPrefs.HasKey("plantInspected") && !FileBasedPrefs.HasKey("compassCollected") && FileBasedPrefs.HasKey("compass"))   
                {
                 compass.SetActive(true);   
                 FileBasedPrefs.SetInt("compassCollected",1);
                }
                else if(FileBasedPrefs.HasKey("GoldenKey") && !FileBasedPrefs.HasKey("knobCollected") ){
                    FileBasedPrefs.SetInt("knobCollected",1);
                    knob.SetActive(true);
                }
                else if(FileBasedPrefs.HasKey("BenardEntryDone") && !FileBasedPrefs.HasKey("UnfriendlyEncounter")){
                    FileBasedPrefs.SetInt("UnfriendlyEncounter",1);
                    SteamHandler.instance.SetAch("Unfriendly Encounter");
                    Debug.Log("Unfriendly Encounter achievement done");
                }
                else if(FileBasedPrefs.HasKey("Room26")){
                    SteamHandler.instance.SetAch("Spookify");
                }
                else if(FileBasedPrefs.HasKey("Room31")){
                    //SteamHandler.instance.SetAch("Mystery Solved");
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