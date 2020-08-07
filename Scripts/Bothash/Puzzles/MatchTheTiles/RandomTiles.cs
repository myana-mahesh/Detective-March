using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTiles : MonoBehaviour
{   
    [SerializeField]
    List <GameObject> tiles=new List<GameObject>();
    [SerializeField]
    List<Transform> pos=new List<Transform>();
    private int randPos;
    // Start is called before the first frame update
    void Start()
    {   
        /* for(int i=0;i<tiles.Count;i++){
            randPos=Random.Range(0,pos.Count);
            if(check(randPos)){
               tiles[i].transform.position=pos[randPos].position;
                pos.RemoveAt(randPos); 
            }
            else{
                i++;
            }
        } */ 
       
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
