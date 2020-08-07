using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStatuePuzzle : MonoBehaviour
{
    [Header("Make Sure to add Emblem prefix/suffix in the puzzle's sprite title that you pick and drop")]
    [Header("Example: Castle Emblem.png")]
    public int emblemPieceCollected = 0;
    public int emblemPieceDropped = 0;
    public GameObject headGear;
    public GameObject dummyGameObject;
}
