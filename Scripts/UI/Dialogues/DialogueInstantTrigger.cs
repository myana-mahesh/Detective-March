using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInstantTrigger : MonoBehaviour {

	public Dialogues dialogues;


    public void Start()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogues);
	}
}
