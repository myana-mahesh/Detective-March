using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
