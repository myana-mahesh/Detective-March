using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLetter : MonoBehaviour {
    public GameObject openLetter;
    // Start is called before the first frame update
    void Start () {
        Debug.Log ("start");
    }

    // Update is called once per frame
    void Update () {

    }
    public void OnMouseDown() {
        Debug.Log ("open");
        openLetter.SetActive (true);
        gameObject.SetActive (false);

    }
}