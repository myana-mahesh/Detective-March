using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bothash {
    public class MatchTheTile : MonoBehaviour {
        //public GameObject toPass;
        private GameObject first;
        private GameObject second;
        public bool firstNotPassed;
        public static MatchTheTile Instance { get; private set; }
        private int count;
        [SerializeField]
        private GameObject Prize;
        public GameObject[] tiles;
        public List<GameObject> dummyTiles = new List<GameObject> ();
        // Start is called before the first frame update

        void Awake () {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad (gameObject);
            } else {
                Destroy (gameObject);
            }
        }
        void Start () {
            int pos;
            count = 0;
            for (int i = 0; i < tiles.Length; i++) {
                pos = UnityEngine.Random.Range (0, dummyTiles.Count);
                tiles[i].transform.position = dummyTiles[pos].transform.position;
                dummyTiles.RemoveAt (pos);
            }
        }
        void Update () {

        }
        /*  
        public void passFirstData (GameObject firstToPass) {
            first = firstToPass;
            first.GetComponent<SpriteRenderer> ().enabled = true;
        }*/
        public void passSecondData (GameObject secondToPass) {
            if (firstNotPassed) {
                first = secondToPass;
                firstNotPassed = false;
                first.GetComponent<SpriteRenderer> ().enabled = true;
            } else {
                second = secondToPass;
                firstNotPassed = true;
                second.GetComponent<SpriteRenderer> ().enabled = true;
                check ();
            }

        }

        public void check () {
            if (first.name == second.name) {
                count += 1;
                first.GetComponent<BoxCollider2D> ().enabled = false;
                second.GetComponent<BoxCollider2D> ().enabled = false;
                if (count == 14) {
                    Prize.SetActive (true);
                }
                Debug.Log ("match");
            } else {
                StartCoroutine (waitFor3 ());;
                Debug.Log ("Notmatch");

            }
        }

        IEnumerator waitFor3 () {
            yield return new WaitForSeconds (0.15f);
            first.GetComponent<SpriteRenderer> ().enabled = false;
            second.GetComponent<SpriteRenderer> ().enabled = false;
        }
    }
}