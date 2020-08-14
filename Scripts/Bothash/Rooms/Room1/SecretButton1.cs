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
        SoundManager.Instance.gameSounds[5].Play();
        gameObject.GetComponent<Animator>().enabled = true;
        SecretKeyManager.Instance.passFirstData(Time.time);
        StartCoroutine(waitFor3());

    }
    IEnumerator waitFor3(){
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Animator>().enabled=false;
        gameObject.GetComponent<SpriteRenderer>().color=new Color(255,255,255,255);
    }
}
