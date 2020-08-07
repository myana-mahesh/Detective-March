using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineTopDrawer : MonoBehaviour {

    public GameObject ExamineDrawer;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (this.gameObject.GetComponent<SpriteRenderer> ().enabled) {
            this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            ExamineDrawer.SetActive (true);
        }
    }
}