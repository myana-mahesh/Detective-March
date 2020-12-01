using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class token : MonoBehaviour
{
    public int randI;
    public int index;
    
    // Start is called before the first frame update
    void Start()
    {
        index=int.Parse(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {   Debug.Log("imaClicled:"+safePuzzleManager.Instance.posAfterRandom[int.Parse(gameObject.name)]);
        safePuzzleManager.Instance.passData(this.gameObject);
        SoundManager.Instance.gameSounds[8].Play();
        /* randI = safePuzzleManager.Instance.posAfterRandom[index];
        if(safePuzzleManager.Instance.adjMatrix[randI,safePuzzleManager.Instance.blankPos]>0){
            safePuzzleManager.Instance.posAfterRandom[index] = safePuzzleManager.Instance.blankPos;
            safePuzzleManager.Instance.blankPos = randI;
            Vector3 temp1 = new Vector3 (0, 0, 0);
            Vector3 temp2 = new Vector3 (0, 0, 0);
            if(safePuzzleManager.Instance.counter==0){
                temp1 = this.gameObject.transform.localPosition;
                this.gameObject.transform.localPosition = safePuzzleManager.Instance.blankTile.transform.position;
            }
            else
            {
                temp2=this.gameObject.transform.localPosition;
                this.gameObject.transform.localPosition=temp1;
                temp1=temp2;
            }
            
            
            //safePuzzleManager.Instance.blankTile.transform.position = temp1;
        } */
    }
}
