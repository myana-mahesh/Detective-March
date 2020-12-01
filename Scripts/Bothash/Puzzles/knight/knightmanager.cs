using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightmanager : MonoBehaviour
{
    public List<GameObject> puzzObj;

    public GameObject blocker;
    // Start is called before the first frame update
    public GameObject mask;

    public PuzzleSaveSO SavingSo;

    public bool RewardProcessed = false;
    string fileName = "KnightPuzzle.puzzle";

    public Vector3 finalPosition;
    public Vector3 rotationVector;

    public string SteamACH = "A Loyal Knight";
    void OnEnable()
    {
        if (LoadData())
        {
            foreach (int i in SavingSo.IndicesOfActiveSpriteRenderer)
            {
                puzzObj[i].GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log(puzzObj[i].gameObject.name);
            }

            RewardProcessed = SavingSo.RewardProcessed;
        }
    }

    void OnDisable()
    {
        SavePuzzleData();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfTouched() || check())
        {
            blocker.SetActive(false);
        }

        if (checkIfTouched() && checkWon())
        {
            if (!RewardProcessed)
            {
                mask.GetComponent<Animator>().enabled = true;
                SteamHandler.instance.SetAch(SteamACH);
                RewardProcessed = true;
            }
            else
            {
                mask.transform.position = finalPosition;
                Quaternion quaternion = new Quaternion();
                quaternion.eulerAngles = rotationVector;
                //quaternion.x = rotationVector.x;
                //quaternion.y = rotationVector.y;
                //quaternion.z = rotationVector.z;
                mask.transform.localRotation = quaternion;
            }
        }
        
    }

    bool checkIfTouched()
    {
        foreach(GameObject obj in puzzObj)
        {
            if (obj.GetComponent<SpriteRenderer>().enabled)
                return true;
        }
        return false;
    }

    bool check()
    {
        int count = 0;
        foreach (var puzz in puzzObj)
        {
            foreach (var item in bothash.InventoryManager.instance.InventorySO.myInventory)
            {
                if (puzz.name == item.puzzlePieceName)
                    count++;
            }
        }

        if (count >= puzzObj.Count)
            return true;
        else
            return false;

    }

    bool checkWon()
    {
        foreach (var item in puzzObj)
        {
            if (!item.GetComponent<SpriteRenderer>().enabled)
                return false;
        }
        return true;
    }

    private void SavePuzzleData()
    {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear();
        foreach (GameObject itemobj in puzzObj)
        {
            SpriteRenderer item = itemobj.GetComponent<SpriteRenderer>();
            if (item.enabled)
            {
                SavingSo.IndicesOfActiveSpriteRenderer.Add(puzzObj.IndexOf(itemobj));
            }
        }

        SavingSo.RewardProcessed = RewardProcessed;
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
