using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace bothash{

public class DedicatedRoomManager : MonoBehaviour {
    [SerializeField]
    List<GameObject> MandatoryObjects = new List<GameObject> ();
    [SerializeField]
    Dictionary<string, GameObject> d = new Dictionary<string, GameObject> ();
    public static DedicatedRoomManager RInstance { get; private set; }
   
    void Awake () {
        if (RInstance == null) {
            RInstance = this;
            DontDestroyOnLoad (gameObject);
        } else {
            Destroy (gameObject);
        }
    }
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void RemoveItemHit (GameObject hittedObject) {
        Debug.Log ("entered");
        if (MandatoryObjects.Contains (hittedObject)) {
            Debug.Log (hittedObject);
            MandatoryObjects.Remove (hittedObject);
        }
    }
    public bool checkStatus () {
        if (MandatoryObjects.Count == 0) {
            return true;
        } else {
            return false;
        }
    }
    public bool checkStatus1 () {
        for (int i = 0; i < MandatoryObjects.Count; i++) {
            if (MandatoryObjects[i].activeSelf) {
                DialogueM.Instance.sentence=MandatoryObjects[i].GetComponent<DialogueAsset>().blockDialogues.sentences;
                DialogueM.Instance.Avatar=MandatoryObjects[i].GetComponent<DialogueAsset>().blockAvatar;
                DialogueM.Instance.Audio=MandatoryObjects[i].GetComponent<DialogueAsset>().blockDialogues.Audios;
                DialogueM.Instance.startDialogue();
                Debug.Log("false");
                return false;
            }
        }
        return true;
    }

}
}