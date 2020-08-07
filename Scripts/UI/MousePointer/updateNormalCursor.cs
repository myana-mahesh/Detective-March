using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateNormalCursor : MonoBehaviour {

    void Start () {

    }

    void OnMouseEnter () {
        MousePointer.Instance.SetNormalPointer ();
    }

}