using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoOpenURL : MonoBehaviour
{
    // Start is called before the first frame update

    public string URL;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        SoundManager.Instance.gameSounds[0].Play();
        Application.OpenURL(URL);
    }
}
