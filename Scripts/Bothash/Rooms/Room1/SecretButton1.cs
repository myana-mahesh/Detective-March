using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButton1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
       /*  if(!SecretKeyManager.Instance.firstPassed){
            SecretKeyManager.Instance.setFirst(Time.time);
            IamHit=true;
        }
        else{
            if(!IamHit || SecretKeyManager.Instance.firstPassed){
                SecretKeyManager.Instance.setSecond(Time.time);
                IamHit=false;
            }
        } */
        SecretKeyManager.Instance.passFirstData(Time.time);
    }
}
