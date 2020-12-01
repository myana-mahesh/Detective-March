using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoomCaibnet : MonoBehaviour {
    string passWord;
    public GameObject prize;
    public GameObject[] pass;
    public static BathRoomCaibnet Instance;
    private void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad (gameObject);
        } else {
            Destroy (gameObject);
        }
    }
    // Start is called before the first frame update
    void Start () {
        passWord = "";
    }

    // Update is called once per frame
    void Update () {

    }
    public void passKey (string keyNum) {
        passWord = passWord + keyNum;
        Debug.Log (passWord);
        showPass ();
        ResetPass ();
    }
    void showPass () {
        for (int i = 0; i < pass.Length; i++) {
            if (!pass[i].activeSelf) {
                pass[i].SetActive (true);
                return;
            }
        }
    }
    void ResetPass () {
        if (passWord.Length == 4) {
            if (passWord == "5218") {
                prize.SetActive (true);
            }
            passWord = "";
            foreach (GameObject item in pass) {
                item.SetActive (false);
            }
        }
    }
}