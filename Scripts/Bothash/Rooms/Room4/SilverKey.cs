using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverKey : MonoBehaviour {
    public GameObject[] examineCasket;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnMouseDown () {
        PlayerPrefs.SetInt ("SilverKeyfound", 1);
        foreach (GameObject item in examineCasket)
        {
            item.GetComponent<BoxCollider2D>().enabled=false;;    
        }
        
    }
}