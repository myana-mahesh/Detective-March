using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineTaps : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnMouseDown () {
        if (!PlayerPrefs.HasKey ("keyDisplayed")) {
            PlayerPrefs.SetInt ("clickedTaps", 1);
        }
    }
}