using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bothash {
    public class CameraHandler : MonoBehaviour {
        public GameObject onCanvasCameraSprite;
        public GameObject CameraFlash;

        private bool _isDragging;
        private bool _dragDone = false;
        private Vector3 PositionAlwaysTo;

        public string[] sentences;
        public GameObject[] character;
        public AudioClip[] Audios;


        public string SteamACH = "Perfect Shot";
        public string tenPhotosACH;
        public string allPhotosACH;
        // Update is called once per frame
        void Awake () {
            PositionAlwaysTo = this.transform.position;
        }

        void Update () {

            if (_isDragging) {
                Vector2 mouseposition = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
                transform.Translate (mouseposition);
            }
        }

        public void OnMouseDown () {
            CameraFlash.SetActive (false);
            Debug.Log ("Camera Clicked");
            _isDragging = true;
            _dragDone = false;

        }
        public void OnMouseUp () {
            Debug.Log ("Camera Released");
            Vector2 mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

            this.GetComponent<BoxCollider2D> ().enabled = false;

            RaycastHit2D hit = Physics2D.Raycast (mousepos, Vector2.zero);
            _isDragging = false;
            _dragDone = true;

            this.GetComponent<BoxCollider2D> ().enabled = true;

            this.transform.position = PositionAlwaysTo;

            if (hit.collider.gameObject.GetComponent<Clickable> () != null) {
                IEnumerator waitForFlash () {
                    yield return new WaitForSeconds (0.8f);
                    if (!FileBasedPrefs.HasKey(hit.collider.gameObject.name))
                    {
                        hit.collider.gameObject.GetComponent<Clickable> ().startClickDialogues ();
                        FileBasedPrefs.SetInt(hit.collider.gameObject.name,1);
                    }
                    
                }
                if (hit.collider.gameObject.GetComponent<Clickable> ().isClickable) {
                    if(hit.collider.gameObject.GetComponent<Clickable> ().albumRefference.activeSelf){
                        bothash.DialogueM.Instance.sentence = sentences;
                        bothash.DialogueM.Instance.Avatar = character;
                        bothash.DialogueM.Instance.Audio = Audios;
                        bothash.DialogueM.Instance.startDialogue ();
                    }
                    else{
                        Debug.Log (hit.collider.gameObject.name + "clicked");
                        hit.collider.gameObject.GetComponent<Clickable> ().albumRefference.SetActive (true);
                        CameraFlash.SetActive (true);

                        SteamHandler.instance.SetAch(SteamACH);
                        if(AlbumManager.Instance.passCounter()==10){
                            Debug.Log("ach set for "+tenPhotosACH);
                            SteamHandler.instance.SetAch(tenPhotosACH);
                        }
                        else if(AlbumManager.Instance.passCounter()==AlbumManager.Instance.images.Length){
                            Debug.Log("ach set for "+allPhotosACH);
                            SteamHandler.instance.SetAch(allPhotosACH);
                        }
                        //disableAnimalExamine.Instance.check();
                        }

                }
                if (hit.collider.gameObject.GetComponent<Clickable> ().haveDilaogues) {
                    
                    StartCoroutine (waitForFlash ());

                }
            }
        }

    }
}