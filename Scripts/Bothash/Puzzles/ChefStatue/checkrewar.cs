using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkrewar : MonoBehaviour
{   
   
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
        
        FileBasedPrefs.SetInt("mendallion1Collcected",1);
        disableAnimalExamine.Instance.check();
    }
}
