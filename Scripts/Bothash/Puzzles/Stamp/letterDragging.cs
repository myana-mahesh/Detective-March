using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterDragging : MonoBehaviour
{
    public bool IsReal = false;
    // Start is called before the first frame update
    private bool _isDragEnded = false;

    public GameObject letterBoxDrop;

    public GameObject Reward;

    private Vector3 ogPositon;
    void Start()
    {
        ogPositon = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        _isDragEnded = false;

    }

    void OnMouseUp()
    {
        _isDragEnded = true;
    }

    void OnMouseDrag()
    {
        _isDragEnded = false;
        var z = this.transform.position.z;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = z;
        Vector3 worldMOuse = Camera.main.ScreenToWorldPoint(mousePos);
        worldMOuse.z = z;
        this.gameObject.transform.localPosition = worldMOuse;


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trigger");
        if (_isDragEnded && IsReal) {
            if(col.gameObject == letterBoxDrop)
            {
                this.gameObject.SetActive(false);
                Reward.SetActive(true);
            }
            else
            {
                this.gameObject.transform.position = ogPositon;
            }
        }
        else
        {
            this.gameObject.transform.position = ogPositon;
            //dialogue
        }
    }

    void OnCollisionEnter2d(Collision2D coll)
    {
        Debug.Log("coll");
    }
}
