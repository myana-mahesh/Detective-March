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
        public GameObject puzzleBox;
        public GameObject blankPosOrg;
        public static Jigsaw Instance { get; set; }

        public List<GameObject> PuzzlePieces;
        int Pcount=0;
        public GameObject blocker;

        public string SteamACH = "Puzzle Master";
        public string SteamACH1 ="Jigsaw Master";
        void OnEnable()
        {
            
            int counter = 0;
            foreach(var pzzItem in PuzzlePieces)
            {
                foreach(var invItem in bothash.InventoryManager.instance.InventorySO.myInventory)
                {
                    if(pzzItem.name == invItem.puzzlePieceName)
                    {
                        counter++;
                    }
                }
            }

            if(touched() || counter >= PuzzlePieces.Count)
            {
                
                SoundManager.Instance.PlayMyMusic("Puzzle");
                blocker.SetActive(false);
                List<string> tmp = new List<string>();

                foreach(var pzzItem in PuzzlePieces)
                {
                    foreach (var invItem in bothash.InventoryManager.instance.InventorySO.myInventory)
                    {
                        if (pzzItem.name == invItem.puzzlePieceName)
                        {

                            tmp.Add(invItem.itemName);

                        }
                    }

                    pzzItem.GetComponent<SpriteRenderer>().enabled = true;
                }

                foreach (var itemNAme in tmp)
                {
                    Destroy(InventoryManager.instance.slotItemDict[itemNAme]);
                    InventoryManager.instance.removeFromInventory(InventoryManager.instance.slotItemDict[itemNAme]);
                }

                //make sprite renderer on and delete them from inventory
            }
            else
            {
                blocker.SetActive(true);
            }
            
            if (Pcount>0){
                blankPos = 15;
                blankTile.transform.position=blankPosOrg.transform.position;
                for (int i = 0; i < tilesPosOrg.Count; i++) {
                tilesPos.Add (tilesPosOrg[i]);
            }
            }
            else{
            for (int i = 0; i < tilesPos.Count; i++) {
                tilesPosOrg.Add (tilesPos[i]);
            }}
            blankPos = 15;
            int pos;
            for (int i = 0; i < tiles.Length; i++) {
                pos = UnityEngine.Random.Range (0, tilesPos.Count);
                tiles[i].transform.localPosition = tilesPos[pos].position;
                posAfterRandom[i] = tilesPosOrg.IndexOf (tilesPos[pos]);
                tilesPos.RemoveAt (pos);
            }
            Pcount++;
            if (FileBasedPrefs.HasKey ("PuzzlePieces")) {
                    puzzleBox.SetActive(false);
            }
        }

        // Start is called before the first frame update
        void Awake () {
            if (Instance == null) {
                Instance = this;
                //DontDestroyOnLoad (gameObject);
            } else {
                Destroy (gameObject);
            }

        }

        void Start () {
            /*blankPos = 15;
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

            if (FileBasedPrefs.HasKey ("PuzzlePieces")) {
                    puzzleBox.SetActive(false);
                }*/

            
            
            
            #region inventoryCheck               
            
            int counter = 0;
            foreach(var pzzItem in PuzzlePieces)
            {
                foreach(var invItem in bothash.InventoryManager.instance.InventorySO.myInventory)
                {
                    if(pzzItem.name == invItem.puzzlePieceName)
                    {
                        counter++;
                    }
                }
            }

            if(touched() || counter >= PuzzlePieces.Count)
            {
                
                SoundManager.Instance.PlayMyMusic("Puzzle");
                blocker.SetActive(false);
                List<string> tmp = new List<string>();

                foreach(var pzzItem in PuzzlePieces)
                {
                    foreach (var invItem in bothash.InventoryManager.instance.InventorySO.myInventory)
                    {
                        if (pzzItem.name == invItem.puzzlePieceName)
                        {

                            tmp.Add(invItem.itemName);

                        }
                    }

                    pzzItem.GetComponent<SpriteRenderer>().enabled = true;
                }

                foreach (var itemNAme in tmp)
                {
                    Destroy(InventoryManager.instance.slotItemDict[itemNAme]);
                    InventoryManager.instance.removeFromInventory(InventoryManager.instance.slotItemDict[itemNAme]);
                }

                //make sprite renderer on and delete them from inventory
            }
            else
            {
                blocker.SetActive(true);
            }
            #endregion
            
            
        }
        private void Update () {
            

        }

        bool touched()
        {
            foreach (var pzzItem in PuzzlePieces)
            {
                if (pzzItem.GetComponent<SpriteRenderer>().enabled)
                    return true;
            }
            return false;
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
            gameObject.GetComponent<Animator>().enabled=true;
            StartCoroutine(waitForAnim());
            
        }
        public void StartJigsaw () {
            blankPos = 15;
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
        IEnumerator waitForAnim(){
            yield return new WaitForSeconds(0.4f);
            SteamHandler.instance.SetAch(SteamACH1);
            OpenBox.SetActive (true);
            if (FileBasedPrefs.HasKey("bigPuzzCount"))
            {
                FileBasedPrefs.SetInt("bigPuzzCount", FileBasedPrefs.GetInt("bigPuzzCount") + 1);
            }
            else
            {
                FileBasedPrefs.SetInt("bigPuzzCount", 1);
            }
            Debug.Log(FileBasedPrefs.GetInt("bigPuzzCount"));
            if (FileBasedPrefs.GetInt("bigPuzzCount") >= 8)
            {
                SteamHandler.instance.SetAch(SteamACH);
            }

            FileBasedPrefs.SetString(this.gameObject.name, "Done");
            puzzleBox.SetActive(false);
        }
    }
}