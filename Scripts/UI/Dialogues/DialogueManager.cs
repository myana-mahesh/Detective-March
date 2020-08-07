using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	//public Text nameText;
	public Text dialogueText;
	private Queue<string> sentences;
	public GameObject nextButton;
	public GameObject dialoguesBox;
	public GameObject blockScreen2D;
	public GameObject blockScreen3D;

    void Start () {
		sentences = new Queue<string>();
	}
	
	public void StartDialogue(Dialogues dialogues)
	{
        Debug.LogWarning("Start Dailogue");
		blockScreen2D.SetActive(true);
		blockScreen3D.SetActive(true);
		//nameText.text = dialogues.name;
		dialoguesBox.SetActive(true);
		sentences.Clear();

		foreach (string sentence in dialogues.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentences();
	}


	public void DisplayNextSentences()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		nextButton.SetActive(true);
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{

		dialogueText.text = "";

		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
        Debug.LogWarning("end Dailogue");
        nextButton.SetActive(false);
		dialoguesBox.SetActive(false);
		blockScreen2D.SetActive(false);
		blockScreen3D.SetActive(false);
		//Debug.Log("End of conversation.");
		
		// todo save dialogue here 		
	}   
}
