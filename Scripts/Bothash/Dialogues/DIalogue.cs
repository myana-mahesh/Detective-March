using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DIalogue", menuName = "DIaloguesObject", order = 0)]
public class DIalogue : ScriptableObject {
    
    public string[] sentences;
    public AudioClip[] Audios;
}
