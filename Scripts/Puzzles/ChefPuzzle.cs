using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefPuzzle : MonoBehaviour
{
    [Header("Make Sure to add Chef prefix in the puzzle's sprite title that you pick and drop")]
    [Header("Example: Chef 1.png")]
    public int itemsCollected = 0;
    public int itemsDropped = 0;
    public GameObject lotusToken;
    public GameObject dummyGameObject;
}
