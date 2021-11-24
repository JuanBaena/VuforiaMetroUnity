using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogueSimple : MonoBehaviour
{
	private string sentence;
	public TextMeshProUGUI dialogueText;

	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	public void StartDialogue(string[] texto)
	{
		sentence = texto[0];
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
}
