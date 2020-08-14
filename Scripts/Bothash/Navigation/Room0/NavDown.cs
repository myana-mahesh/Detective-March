using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bothash{

public class NavDown : MonoBehaviour {
    [SerializeField]
    public GameObject nextRoom;
    [SerializeField]
    private GameObject cuurRoom;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnMouseDown () {
        if (DedicatedRoomManager.RInstance.checkStatus1 ()) {
            Debug.Log ("hit");
            SoundManager.Instance.gameSounds[0].Play();
            cuurRoom.SetActive (false);
            nextRoom.SetActive (true);
        }
    }
}
}