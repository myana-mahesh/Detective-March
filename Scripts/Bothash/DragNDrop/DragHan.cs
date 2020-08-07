using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHan : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject toPos;
    private float startPosX;
    private float startPosY;
    private bool moving;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (moving) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint (mousePos);
            this.gameObject.transform.localPosition = new Vector3 (mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }

    }
    private void OnMouseDown () {
        if (Input.GetMouseButtonDown (0)) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint (mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            moving = true;

        }
    }
    private void OnMouseUp () {
        moving = false;

    }
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "jigsaw") {
            Debug.Log ("trigger");
            gameObject.transform.localPosition = toPos.transform.localPosition;
        }
    }
}