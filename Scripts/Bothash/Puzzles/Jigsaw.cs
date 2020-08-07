using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace bothash {
    public class Jigsaw : MonoBehaviour {
        [SerializeField]
        List<Transform> tilesPos = new List<Transform> ();
        List<Transform> tilesPosOrg = new List<Transform> ();
        public int[] posAfterRandom;
        [SerializeField]
        private GameObject[] tiles;
        public GameObject blankTile;
        public int blankPos;
        public GameObject OpenBox;
        public static Jigsaw Instance { get; set; }

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
            blankPos = 14;
            for (int i = 0; i < tilesPos.Count; i++) {
                tilesPosOrg.Add (tilesPos[i]);
            }

            int pos;
            for (int i = 0; i < tiles.Length; i++) {
                pos = UnityEngine.Random.Range (0, tilesPos.Count);
                tiles[i].transform.localPosition = tilesPos[pos].position;
                posAfterRandom[i] = tilesPosOrg.IndexOf (tilesPos[pos]);
                tilesPos.RemoveAt (pos);
            }
        }
        private void Update () {

        }
        public bool checkRandompos () {
            for (int i = 0; i < posAfterRandom.Length; i++) {
                if (posAfterRandom[i] != i) {
                    return false;
                }
            }
            return true;
        }
        public void ActivateBox () {
            OpenBox.SetActive (true);
        }
        public void StartJigsaw () {
            blankPos = 14;
            for (int i = 0; i < tilesPos.Count; i++) {
                tilesPosOrg.Add (tilesPos[i]);
            }

            int pos;
            for (int i = 0; i < tiles.Length; i++) {
                pos = UnityEngine.Random.Range (0, tilesPos.Count);
                tiles[i].transform.localPosition = tilesPos[pos].position;
                posAfterRandom[i] = tilesPosOrg.IndexOf (tilesPos[pos]);
                tilesPos.RemoveAt (pos);
            }
        }
    }
}