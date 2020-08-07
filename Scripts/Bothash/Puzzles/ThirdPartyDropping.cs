using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPartyDropping : MonoBehaviour
{
    public GameObject ThirdPartyObject;
    // Start is called before the first frame update

    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateThirdParty()
    {
        Debug.Log("Initiating Thrd Party");
        Debug.Log(string.Format("Third Party Object Name: {0}", ThirdPartyObject.name));
        ThirdPartyObject.SetActive(true);
    }
}
