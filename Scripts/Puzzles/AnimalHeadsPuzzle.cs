using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHeadsPuzzle : MonoBehaviour
{
    [Header("Make Sure to add Eye prefix in the puzzle's sprite title that you pick and drop")]
    [Header("Example: Eye 1.png")]
    public int eyesCollected = 0;
    public int eyesDropped = 0;
    public GameObject medallion;
    public GameObject dummyGameObject;
}
