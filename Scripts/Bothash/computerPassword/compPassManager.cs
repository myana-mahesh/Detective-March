using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compPassManager : MonoBehaviour
{
    string passWord;
    public GameObject currRoom;
    public GameObject prize;
    public GameObject[] pass;
    public GameObject type;
    public GameObject navToComp;
    public GameObject navToPuzz;
    public static compPassManager Instance;
    void Awake () 
    {
        if (Instance == null) {
                Instance = this;
                //DontDestroyOnLoad (gameObject);
            } 
        else {
            Destroy (gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        passWord = "";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void passKey (string keyNum) {
        if(passWord.Length<5){
        passWord = passWord + keyNum;
        Debug.Log ("PAss is"+passWord);
        showPass ();}
        //ResetPass ();
    }
    void showPass () {
        for (int i = 0; i < pass.Length; i++) {
            if (!pass[i].activeSelf) {
                pass[i].SetActive (true);
                type.transform.position=new Vector3(type.transform.position.x+0.173f,type.transform.position.y,type.transform.position.z);
                return;
            }
        }
    }
    public void ResetPass () {
        
            if (passWord == "97583") {
                prize.SetActive (true);
                currRoom.SetActive(false);
                navToComp.SetActive(false);
                navToPuzz.SetActive(true);
            }
            passWord = "";
            type.transform.localPosition=new Vector3(-1.32f,type.transform.localPosition.y,type.transform.localPosition.z);            
            foreach (GameObject item in pass) {
                item.SetActive (false);
        
        }
    }
}
