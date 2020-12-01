using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showRestart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator showRestart(){
        yield return new WaitForSeconds(60);
        canvas.SetActive(true);
    }
}
