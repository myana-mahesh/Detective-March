using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCasket : MonoBehaviour {
    public SpriteRenderer mendalion0;
    public SpriteRenderer mendalion1;
    public GameObject OpenBox;
    public GameObject[] mendalions;

    public PuzzleSaveSO SavingSo;
    private string fileName = "silvercasket.puzzle";
    // Start is called before the first frame update
    void Start () {
        if (LoadData())
        {
            foreach(int i in SavingSo.IndicesOfActiveSpriteRenderer)
            {
                if (i == 0)
                    mendalion0.enabled = true;
                if (i == 1)
                    mendalion1.enabled = true;
            }
        }
    }

    void OnDisable()
    {
        SaveData();
        
    }

    // Update is called once per frame
    void Update () {
        if (mendalion1.enabled && mendalion0.enabled) {
            OpenBox.SetActive (true);
            foreach (GameObject item in mendalions)
            {
                item.SetActive(false);
            }
            FileBasedPrefs.SetInt ("SilverCasketComplete", 1);
        }
    }


    bool LoadData()
    {
        if (PuzzleDataSaveLoad.instance.Load(SavingSo, fileName) != null)
        {
            SavingSo = PuzzleDataSaveLoad.instance.Load(SavingSo, fileName);
            return true;
        }
        else
        {
            return false;
        }
    }

    void SaveData()
    {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear();
        if (mendalion0.enabled)
            SavingSo.IndicesOfActiveSpriteRenderer.Add(0);
        if (mendalion1.enabled)
            SavingSo.IndicesOfActiveSpriteRenderer.Add(1);

        PuzzleDataSaveLoad.instance.Save(SavingSo, fileName);
    }
}