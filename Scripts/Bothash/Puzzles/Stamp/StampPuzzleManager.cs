using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampPuzzleManager : MonoBehaviour
{
    public SimpleDropManager dropManager;
    private int countOfObj;
    public GameObject LetterBlank;
    public GameObject reward;
    private bool rewardDeployed = false;
    private bool puzzleStarted = false;
    bool dataLoaded = false;
    public List<bothash.InventoryItemSO> DropList;
    // Start is called before the first frame update

    public GameObject blocker;

    public PuzzleSaveSO SavingSo;

    private string fileName = "StampPuzzle.puzzle";

    public GameObject nibAnim;
    public GameObject bangleAnim;
    public GameObject emblemAnim;
    public GameObject scarfAnim;


    public GameObject nibStampMark;
    public GameObject bangleStampMark;
    public GameObject emblemStampMark;
    public GameObject scarfStampMark;

    public string SteamACH = "Stamp Paid";
    void OnEnable()
    {
        dataLoaded = false;
        StartCoroutine(waitforload());
        
    }

    IEnumerator waitforload()
    {
        

        yield return new  WaitUntil(() => isValidFn() == true);
        LoadingFn();
               
    }

    bool isValidFn()
    {
        try
        {
            LoadData();
            return true; 
        }
        catch(System.Exception)
        {
            return false;
        }
    }

    void LoadingFn()
    {
        if (LoadData())
        {
            countOfObj = SavingSo.DroppedCount;
            puzzleStarted = SavingSo.PuzzleCompleted;
            rewardDeployed = SavingSo.RewardProcessed;
        }
        else
        {
            Debug.Log("###### FRESH STAMP PUZZLE ######");
            puzzleStarted = false;
            rewardDeployed = false;
            countOfObj = DropList.Count;
        }

        if (puzzleStarted)
        {
            Debug.Log("Firing Blocker false from start");
            blocker.SetActive(false);
        }
        /*if (rewardDeployed)
        {
            Debug.Log("Firing rewards");
            reward.SetActive(true);
            LetterBlank.SetActive(false);
        }*/

        Debug.LogFormat("COUNT OF IBJ : {0}", countOfObj);

        dataLoaded = true;
    }
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (dataLoaded)
        {
            //Debug.LogFormat("DROPPED : {0} | COUNTOFOBJ : {1} | DROPLIST : {2}", dropManager.GetDatas().Count, countOfObj,DropList.Count);
            if (chechAllPiece() && !puzzleStarted)
            {
                Debug.Log("######## BLOCKER INACTIVE #######");
                blocker.SetActive(false);
                puzzleStarted = true;
            }

            if (puzzleStarted)
            {
                if (dropManager.GetDatas() != null)
                {
                    foreach (bothash.InventoryItemSO item in dropManager.GetDatas())
                    {
                        switch (item.itemName)
                        {
                            case "Pen NIb":
                                nibAnim.SetActive(true);
                                nibStampMark.SetActive(false);
                                break;
                            case "Bangle":
                                bangleAnim.SetActive(true);
                                bangleStampMark.SetActive(false);
                                break;
                            case "Sun Emblem":
                                emblemAnim.SetActive(true);
                                emblemStampMark.SetActive(false);
                                break;
                            case "Dwarf Cap":
                                scarfAnim.SetActive(true);
                                scarfStampMark.SetActive(false);
                                break;
                        }
                    }
                }

                if (dropManager.GetDatas() != null && dropManager.GetDatas().Count >= countOfObj && !rewardDeployed)
                {
                    LetterBlank.SetActive(false);
                    Debug.LogFormat("###### COUNT OF DROPPED OBJECTS : {0} AND COUND OF TOTAL DROPPING {0}", dropManager.GetDatas().Count, countOfObj);
                    reward.SetActive(true);
                    SteamHandler.instance.SetAch(SteamACH);
                    rewardDeployed = true;

                }
            }
        }


        
    }


    void OnDisable()
    {
        if (puzzleStarted && !rewardDeployed)
        {
            if (dropManager.GetDatas() != null)
            {
                Debug.LogFormat("######%%%%%% COUNT OF DROPPED OBJECTS : {0} AND COUND OF TOTAL DROPPING {1}", dropManager.GetDatas().Count, countOfObj);
                countOfObj -= dropManager.GetDatas().Count;
                Debug.LogFormat("###### COUNT OF DROPPED OBJECTS : {0} AND COUND OF TOTAL DROPPING {1}", dropManager.GetDatas().Count, countOfObj);
            }
        }

        SavePuzzleData();
    }

    bool chechAllPiece()
    {
        int count = 0;
        foreach(bothash.InventoryItemSO invSoOg in DropList)
        {
            foreach(bothash.InventoryItemSO invSo in bothash.InventoryManager.instance.InventorySO.myInventory)
            {
                if (invSo.itemName == invSoOg.itemName)
                    count++;
            }
        }
        if (count == DropList.Count)
            return true;
        else
            return false;
    }

    private void SavePuzzleData()
    {

        SavingSo.DroppedCount = countOfObj;
        SavingSo.RewardProcessed = rewardDeployed;
        SavingSo.PuzzleCompleted = puzzleStarted;
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
