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
        if (FileBasedPrefs.HasKey ("BenardEntryDone") && !FileBasedPrefs.HasKey ("NavAfterBenardEntry")) {
            FileBasedPrefs.SetInt ("NavAfterBenardEntry", 1);
            Block1stFLoorNav.SetActive (false);

        }
    }
}