using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "item", menuName = "PuzzleSaveSO/abcpuzzSave")]
[System.Serializable]
public class PuzzleSaveSO : ScriptableObject
{
    public List<int> IndicesOfActiveSpriteRenderer;
    public bool RewardProcessed;
    public bool PuzzleCompleted;
    public bool RewardCollected;
}
