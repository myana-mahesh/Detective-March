using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAfterSilver : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject Block1stFLoorNav;
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnMouseDown () {
        if (PlayerPrefs.HasKey ("BenardEntryDone") && !PlayerPrefs.HasKey ("NavAfterBenardEntry")) {
            PlayerPrefs.SetInt ("NavAfterBenardEntry", 1);
            Block1stFLoorNav.SetActive (false);

        }
    }
}