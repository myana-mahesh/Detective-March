using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretKeyManager : MonoBehaviour
{   
    private float firstButton;
    private float secondButton;
    [SerializeField]
    private GameObject Drawer;
    [SerializeField]
    private GameObject Room1;
    public bool firstPassed;
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
    public void passFirstData(float t){
        firstButton=t;
    }
    public void passData(float seconds){
        /* if(!firstPassed){
            firstButton=seconds;
            Debug.Log(firstButton);
            firstPassed=true;
        } */
      /*   else{ */
            secondButton=seconds;
            Debug.Log(secondButton);
            /* firstPassed=false; */  
            
            if(secondButton-firstButton<=3){
                Drawer.SetActive(true);
                Room1.SetActive(false);
            }
            else{
                Debug.Log("fail");
                }
        }
}
