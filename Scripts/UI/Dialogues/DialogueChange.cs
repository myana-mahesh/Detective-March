﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChange : MonoBehaviour
{
    public KeyCode mouseClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (mouseClick))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentences();
        }
        
    }
}
