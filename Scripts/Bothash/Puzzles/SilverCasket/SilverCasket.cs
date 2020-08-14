using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCasket : MonoBehaviour {
    public SpriteRenderer mendalion0;
    public SpriteRenderer mendalion1;
    public GameObject OpenBox;
    public GameObject[] mendalions;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (mendalion1.enabled && mendalion0.enabled) {
            OpenBox.SetActive (true);
            foreach (GameObject item in mendalions)
            {
                item.SetActive(false);
            }
            PlayerPrefs.SetInt ("SilverCasketComplete", 1);
        }
    }
}