using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCasketManager : MonoBehaviour
{
    public List<GameObject> lotusPetals;
    public GameObject reward;
    public GameObject roomswitch;
    public   GameObject casket;

    public PuzzleSaveSO SavingSo;

    string fileName = "Diamondcasket.puzzle";
    // Start is called before the first frame update

        void OnEnable()
    {
        if (LoadData())
        {
            foreach (int i in SavingSo.IndicesOfActiveSpriteRenderer)
            {
                lotusPetals[i].GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log(lotusPetals[i].gameObject.name);
            }
        }
    }

    void OnDisable()
    {
        
        SavePuzzleData();
    }
    void Start()
    {
        chechifDone();
    }

    // Update is called once per frame
    void Update()
    {
        if (chechifDone() && !reward.activeSelf)
        {
            reward.SetActive(true);
            casket.SetActive(true);
            //roomswitch.SetActive(true);
        }
    }

    bool chechifDone()
    {
        foreach (GameObject lotusPetal in lotusPetals)
        {
            if (!lotusPetal.GetComponent<SpriteRenderer>().enabled)
                return false;
        }

        return true;
    }

    private void SavePuzzleData()
    {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear();
        foreach (GameObject itemobj in lotusPetals)
        {
            SpriteRenderer item = itemobj.GetComponent<SpriteRenderer>();
            if (item.enabled)
            {
                SavingSo.IndicesOfActiveSpriteRenderer.Add(lotusPetals.IndexOf(itemobj));
            }
        }
        //calll savepuzzdatamanger with the so and nameofthefile

        PuzzleDataSaveLoad.instance.Save(SavingSo, fileName);

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
}
