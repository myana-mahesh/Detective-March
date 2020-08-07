using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiqueBoxSave : MonoBehaviour
{
    public List<SpriteRenderer> paintingSprites = new List<SpriteRenderer>();
    
    [SerializeField]
    private PuzzleSaveSO SavingSo;

    private string fileName = "jigsaw.puzzle";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnable()
    {
        if (LoadPuzzleData())
        {
            foreach (int i in SavingSo.IndicesOfActiveSpriteRenderer)
            {
                paintingSprites[i].enabled = true;
            }
        }
    }

    public void OnDisable()
    {
        SavePuzzleData();
    }


    private void SavePuzzleData()
    {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear();
        foreach (SpriteRenderer item in paintingSprites)
        {
            if (item.enabled)
            {
                SavingSo.IndicesOfActiveSpriteRenderer.Add(paintingSprites.IndexOf(item));
            }
        }



        //calll savepuzzdatamanger with the so and nameofthefile

        PuzzleDataSaveLoad.instance.Save(SavingSo, fileName);

    }

    private bool LoadPuzzleData()
    {
        //call savepuzzmanager with the name of file and pass the so
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
}
