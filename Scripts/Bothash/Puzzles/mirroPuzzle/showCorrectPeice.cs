using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCorrectPeice : MonoBehaviour
{
    public GameObject correctPiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        correctPiece.SetActive(true);
        gameObject.SetActive(false);
    }
}
