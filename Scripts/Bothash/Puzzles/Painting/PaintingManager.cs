using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour {
    public List<SpriteRenderer> paintingSprites = new List<SpriteRenderer> ();
    public GameObject Prize;
    [SerializeField]
    private PuzzleSaveSO SavingSo;
    private string fileName = "Painting.puzzle";
    // Start is called before the first frame update
    void Start () {

    }

    public void OnEnable () {
        if (LoadPuzzleData ()) {
            foreach (int i in SavingSo.IndicesOfActiveSpriteRenderer) {
                paintingSprites[i].enabled = true;
            }
        }
    }

    public void OnDisable () {
        SavePuzzleData ();
    }

    // Update is called once per frame
    void Update () {
        if (checkStatus ()) {
            Prize.SetActive (true);

            if (!PlayerPrefs.HasKey ("paintigOjectsPicked")) {
                PlayerPrefs.SetInt ("PantingSolved", 1);
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