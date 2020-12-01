using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photo : MonoBehaviour
{
    public Transform corrPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        photoPuzzleManager.Instance.passData (this.gameObject);
    }
    public void check(){
        Debug.Log("checkExecuted");
        if(gameObject.transform.position==corrPosition.transform.position){
            photoPuzzleManager.Instance.counter+=1;
            gameObject.GetComponent<BoxCollider2D>().enabled=false;
            Debug.Log("disabled");
        }
    }
}
