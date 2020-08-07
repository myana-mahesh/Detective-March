using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampPuzzle : MonoBehaviour
{
    [Header("Make Sure to add Stamp prefix in the puzzle's sprite title that you pick and drop")]
    [Header("Example: Stamp 1.png")]
    public int stampCollected = 0;
    public int stampDropped = 0;
    public GameObject postbox;
    public GameObject dummyGameObject;
}
