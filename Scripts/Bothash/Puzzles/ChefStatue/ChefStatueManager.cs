using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefStatueManager : MonoBehaviour {
    public List<SpriteRenderer> paintingSprites = new List<SpriteRenderer> ();
    public GameObject Prize;
    [SerializeField]
    private PuzzleSaveSO SavingSo;
    private string fileName = "ChefStatue.puzzle";
    private bool _puzzleComplete=false;
    public List<GameObject> PuzzlePieces;
    public GameObject blocker;
    public string SteamACH="Pro Chef";
    // Start is called before the first frame update
    void Start () {

    }

    void Update () {
        if (checkStatus () && !_puzzleComplete) {
            Prize.SetActive (true);
            _puzzleComplete = true;
            SteamHandler.instance.SetAch(SteamACH);
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
    public void OnEnable () {
        if (LoadPuzzleData ()) {
            Debug.Log("Data in SO");
            foreach (int i in SavingSo.IndicesOfActiveSpriteRenderer) {
                paintingSprites[i].enabled = true;
            }

            _puzzleComplete = SavingSo.PuzzleCompleted;
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

    private void SavePuzzleData () {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear ();
        foreach (SpriteRenderer item in paintingSprites) {
            if (item.enabled) {
                SavingSo.IndicesOfActiveSpriteRenderer.Add (paintingSprites.IndexOf (item));
            }
        }

        SavingSo.PuzzleCompleted = _puzzleComplete;

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