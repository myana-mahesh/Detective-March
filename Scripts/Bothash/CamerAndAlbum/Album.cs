using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Album : MonoBehaviour {
    public GameObject BigPhoto;
    // Start is called before the first frame update
    private void OnMouseDown () {
        BigPhoto.SetActive (true);
    }
}