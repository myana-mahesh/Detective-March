using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class albumSlidesMove : MonoBehaviour
{
    public GameObject Photos;
    

    public Vector3 minX;
    public Vector3 maxX;

    public float factor = 20f;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveRight()
    {
        if(Photos.transform.localPosition.x > maxX.x) 
        Photos.transform.localPosition -= new Vector3(factor,0,0);
        
    }
    public void moveLeft()
    {
        if(Photos.transform.localPosition.x < minX.x) 
        Photos.transform.localPosition += new Vector3(factor,0,0);
        
    }
}
