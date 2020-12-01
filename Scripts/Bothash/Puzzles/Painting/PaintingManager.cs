using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour {
    public List<SpriteRenderer> paintingSprites = new List<SpriteRenderer> ();
    public GameObject Prize;
    public GameObject painting;
    public GameObject examinePainting;
    [SerializeField]
    private PuzzleSaveSO SavingSo;
    private string fileName = "Painting.puzzle";
    public List<GameObject> PuzzlePieces;
    bool puzzleCompleted;
    public GameObject blocker;
    // Start is called before the first frame update

    public string SteamACH = "Puzzle Master";
    public string SteamACH1="Repaired & Restored";
    void Start () {

    }

    public void OnEnable () {
        if (LoadPuzzleData ()) {
            foreach (int i in SavingSo.IndicesOfActiveSpriteRenderer) {
                paintingSprites[i].enabled = true;
            }
        }

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
        if(counter>=PuzzlePieces.Count){
            blocker.SetActive(false);
            

        }
    }

    public void OnDisable () {
        SavePuzzleData ();
    }

    // Update is called once per frame
    void Update () {
        if (checkStatus () && !puzzleCompleted) {
            Prize.SetActive (true);
            painting.SetActive(true);
            SteamHandler.instance.SetAch(SteamACH1);
            puzzleCompleted=true;
            //examinePainting.SetActive(false);
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





            if (!FileBasedPrefs.HasKey ("paintigOjectsPicked")) {
                FileBasedPrefs.SetInt ("PantingSolved", 1);
            }

        }
    }
    bool checkStatus () {
        for (int i = 0; i < paintingSprites.Count; i++) {
            if (!paintingSprites[i].enabled) {
                return false;
            }
        }
        return true;
    }

    private void SavePuzzleData () {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear ();
        foreach (SpriteRenderer item in paintingSprites) {
            if (item.enabled) {
                SavingSo.IndicesOfActiveSpriteRenderer.Add (paintingSprites.IndexOf (item));
            }
        }

        //calll savepuzzdatamanger with the so and nameofthefile

        PuzzleDataSaveLoad.instance.Save (SavingSo, fileName);

    }

    private bool LoadPuzzleData () {
        //call savepuzzmanager with the name of file and pass the so
        if (PuzzleDataSaveLoad.instance.Load (SavingSo, fileName) != null) {
            SavingSo = PuzzleDataSaveLoad.instance.Load (SavingSo, fileName);
            return true;
        } else {
            return false;
        }

    }

}