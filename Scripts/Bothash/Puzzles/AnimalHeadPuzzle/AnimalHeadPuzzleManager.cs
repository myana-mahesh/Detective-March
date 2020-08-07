using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHeadPuzzleManager : MonoBehaviour {
    // Start is called before the first frame update

    public List<SpriteRenderer> listOfPuzzlePieces;
    public GameObject BlockingObject;
    public GameObject RewardObject;
    public GameObject ParentRoom;
    public PuzzleSaveSO SavingSo;

    private int _totalEyesDroped = 0;

    private bool _isRewardProcessed = false;
    private bool _isPuzzleCompleted = false;
    private bool _rewardCollected = false;

    private bool _alreadyLoaded = false;

    private string fileName = "AnimalHeadData.puzzle";

    public void OnEnable () {

        var status = LoadPuzzleData ();

        if (status) {
            foreach (int index in SavingSo.IndicesOfActiveSpriteRenderer) {
                listOfPuzzlePieces[index].enabled = true;
                ++_totalEyesDroped;
                _alreadyLoaded = true;
            }
            _isRewardProcessed = SavingSo.RewardProcessed;
            _rewardCollected = SavingSo.RewardCollected;
            _isPuzzleCompleted = SavingSo.PuzzleCompleted;
        }

        if (_isPuzzleCompleted && _isRewardProcessed && _rewardCollected) {
            ParentRoom.SetActive (false);
        }

    }

    public void OnDisable () {
        SavePuzzleData ();
    }

    public void LoadPuzzle () {
        Debug.Log ("Looking");
        if (!_alreadyLoaded) {
            foreach (var item in listOfPuzzlePieces) {
                Debug.Log (bothash.InventoryManager.instance.InventorySO.myInventory.Count);
                if (bothash.InventoryManager.instance.InventorySO.myInventory.Count > 0) {
                    foreach (var invItem in bothash.InventoryManager.instance.InventorySO.myInventory) {

                        Debug.Log ("In Loop");

                        if (item.gameObject.name != invItem.puzzlePieceName) {
                            Debug.Log ("Not Enough Items");
                            return;
                        } else {
                            Debug.Log ("found out a piece");
                            continue;
                        }
                    }
                } else {
                    return;
                }
            }
        }

        BlockingObject.SetActive (false);

        //load puzzle

    }

    // Update is called once per frame
    void Update () {
        if (_totalEyesDroped <= listOfPuzzlePieces.Count && !_isPuzzleCompleted) {

            _totalEyesDroped = 0;
            foreach (var item in listOfPuzzlePieces) {
                if (item.enabled)
                {
                    ++_totalEyesDroped;
                    Debug.Log(string.Format("FOUNT {0}", _totalEyesDroped));
                }

            }

            if(_totalEyesDroped >= listOfPuzzlePieces.Count)
            {
                Debug.Log("WON");
                RewardObject.SetActive(true);
                _isRewardProcessed = true;
                _isPuzzleCompleted = true;
            }

        } else if (!_isRewardProcessed) {
            _isRewardProcessed = true;
            RewardObject.SetActive (true);
            
        }
        

        /* else if(_isRewardProcessed && !_rewardCollected)
        {
            RewardObject.SetActive(true);
        } */
    }

    //Should be calle after collecting mendallion
    public void CollectReward () {
        _rewardCollected = true;
        _isPuzzleCompleted = true;

    }

    private void SavePuzzleData () {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear ();
        foreach (SpriteRenderer item in listOfPuzzlePieces) {
            if (item.enabled) {
                SavingSo.IndicesOfActiveSpriteRenderer.Add (listOfPuzzlePieces.IndexOf (item));
            }
        }

        SavingSo.PuzzleCompleted = _isPuzzleCompleted;
        SavingSo.RewardCollected = _rewardCollected;
        SavingSo.RewardProcessed = _isRewardProcessed;

        //calll savepuzzdatamanger with the so and nameofthefile

        PuzzleDataSaveLoad.instance.Save (SavingSo, fileName);

    }

    public bool LoadPuzzleData () {
        //call savepuzzmanager with the name of file and pass the so
        if (PuzzleDataSaveLoad.instance.Load (SavingSo, fileName) != null) {
            SavingSo = PuzzleDataSaveLoad.instance.Load (SavingSo, fileName);
            return true;
        } else {
            return false;
        }

    }
}