using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetHide : MonoBehaviour
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
        SoundManager.Instance.gameSounds[4].Play();
        this.gameObject.SetActive(false);
    }
}
