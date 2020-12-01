using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzleOnClick : MonoBehaviour
{
    // Start is called before the first frame update

    public AnimalHeadPuzzleManager manager;
    void Start()
    {
        
    }

    public void OnEnable()
    {
        Debug.Log("This is LoadPuzzle Trigger");
    }

    void OnMouseEnter ()
    {
        Debug.Log("Mouse Over me");
        manager.LoadPuzzle();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
