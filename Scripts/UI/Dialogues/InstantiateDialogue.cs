using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDialogue : MonoBehaviour
{

    public GameObject currentDialoguesPrefab;
    public GameObject blockScreen2D;
    public GameObject blockScreen3D;
    public float dailougeTime = 1;

    public void Start()
    {
        Debug.Log("Start dialogue");
        blockScreen2D.SetActive(true);
        blockScreen3D.SetActive(true);
        Invoke("Dialogue3Display", dailougeTime);
    }

    public void Dialogue3Display()
    {
        // todo save dialogue 
        if (FileBasedPrefs.HasKey(currentDialoguesPrefab.name))
        {
            Debug.Log("Start dialogue s1");
            FindObjectOfType<DialogueManager>().DisplayNextSentences();
            return;
        }
        else
        {
            Debug.Log("Start dialogue s2");
            FileBasedPrefs.SetString(currentDialoguesPrefab.name, "showed_once");
            Instantiate(currentDialoguesPrefab);
            //Debug.LogWarning(FileBasedPrefs.GetString(currentDialoguesPrefab.name));
        }
    }


}
