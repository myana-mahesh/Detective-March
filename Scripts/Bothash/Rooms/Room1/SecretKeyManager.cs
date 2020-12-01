using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SecretKeyManager : MonoBehaviour
{   
    public GameObject secretButton;
    public GameObject secretButton1;
    private float firstButton;
    private float secondButton;
    [SerializeField]
    private GameObject Drawer;
    [SerializeField]
    private GameObject Room1;
    public bool firstPassed,secondPassed;
    public GameObject navToTop;
    public GameObject examineTop;

    public string SteamACH = "Keen Eye";
    public static  SecretKeyManager Instance{get;private set;}
    // Start is called before the first frame update
    void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    void Start()
    {   
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void passFirstData(float seconds){
        firstButton=seconds;
        Debug.Log(firstButton);
        firstPassed=true;
        if(firstPassed && secondPassed){
            if(Math.Abs(secondButton-firstButton)<=3 ){
                
                Drawer.SetActive(true);
                SteamHandler.instance.SetAch(SteamACH);
                secretButton.SetActive(false);
                secretButton1.SetActive(false);
                Room1.SetActive(false);
                navToTop.SetActive(true);
                examineTop.SetActive(false);
                secretButton.GetComponent<Animator>().enabled=false;
                secretButton.GetComponent<SpriteRenderer>().color=new Color(255,255,255,255);
                secretButton1.GetComponent<Animator>().enabled=false;
                secretButton1.GetComponent<SpriteRenderer>().color=new Color(255,255,255,255);
            }
            else
            {
                Debug.Log("fail");
            }
            firstPassed=false;
            secondPassed=false;
       } 
        
    }
    public void passSecondData(float seconds){
        secondButton=seconds;
        Debug.Log(secondButton);
        secondPassed=true;
        if(firstPassed && secondPassed){
            if(Math.Abs(secondButton-firstButton)<=3 ){
                Drawer.SetActive(true);
                SteamHandler.instance.SetAch(SteamACH);
                secretButton.SetActive(false);
                secretButton1.SetActive(false);
                Room1.SetActive(false);
                navToTop.SetActive(true);
                examineTop.SetActive(false);
                secretButton.GetComponent<Animator>().enabled=false;
                secretButton.GetComponent<SpriteRenderer>().color=new Color(255,255,255,255);
                secretButton1.GetComponent<Animator>().enabled=false;
                secretButton1.GetComponent<SpriteRenderer>().color=new Color(255,255,255,255);
            }
            else
            {
                Debug.Log("fail");
            }
            firstPassed=false;
            secondPassed=false;
       } 
    }

    /* public void passData(float seconds){
         /* if(!firstPassed){
            
            
        }/*   /*
         else{ 
            secondButton=seconds;
            Debug.Log(secondButton);
             firstPassed=false;   
            
            
        }
    }
    IEnumerator clearFirst(){
        yield return new WaitForSeconds(3);
        firstPassed=false;
    } */ 
}
