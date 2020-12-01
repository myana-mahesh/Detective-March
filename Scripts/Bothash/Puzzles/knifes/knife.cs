using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
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

        this.gameObject.GetComponent<Animator>().SetTrigger("Knife");
        knifeManager.Instance.passSecondData (this.gameObject);
        SoundManager.Instance.gameSounds[10].Play();
    }
}
