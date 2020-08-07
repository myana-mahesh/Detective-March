using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ObjectSavingSo", menuName = "ObjectSavingSo", order = 0)]
public class ObjectSavingSo : ScriptableObject
{
    public List<int> GameData = new List<int>();
    public List<int> AnimatingObjectsIndexes = new List<int>();
    public List<AnimatorObjects> AnimatingObjectsData;


}



[System.Serializable]
public class AnimatorObjects
{
    public bool playOnlyOnce;
    public bool positionHold;
    public Vector3 PositonToHold;
}

[System.Serializable]
public class AnimatingObjectsClass
{
    public Animator AnimatingObject;
    public bool playOnlyOnce;
    public bool positionHold;
    public Vector3 PositonToHold;
}