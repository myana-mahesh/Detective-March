using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour
{
    [Header("Make Sure to add Art prefix in the puzzle's sprite title that you pick and drop")]
    [Header("Example: Art 1.png")]
    public int artCollected = 0;
    public int artDropped = 0;
    public GameObject painting;
    public GameObject dummyGameObject;
}