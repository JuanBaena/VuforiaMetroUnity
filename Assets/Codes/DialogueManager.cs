using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour {

    #region UnityObjects
    public TextMeshProUGUI dialogueText;
	public Animator animator;
	public Animator BtnVermas;
	public Animator ExpandedBox;
    #endregion

    #region LocalVariables
    private Queue<string> sentences;
	int i;
	public bool MessageActive = false;
	public bool TouchesDialogues = false;
	public string[] Message;
    #endregion

    void Start () {
		sentences = new Queue<string>();
		BtnVermas.SetBool("VerIsOpen",false);
	}

	public void StartDialogue (string[] texto)
	{
		i = 0;
		Message = texto;
		MessageActive = false;
		BtnVermas.SetBool("VerIsOpen", true);
		ExpandedBox.SetBool("Expanded",false);
		sentences.Clear();
		foreach (string sentence in texto)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	public void DisplayNextSentence ()
	{
		i++;
		if (i>=Message.Length)
		{
			BtnVermas.SetBool("VerIsOpen", false);
		}
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		if (MessageActive)
		{
			ExpandedBox.SetBool("Expanded", true);
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		MessageActive = true;
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
		if (TouchesDialogues)
		{
			FindObjectOfType<Collider_select>().StopFlashing();
		}
		StopAllCoroutines();
		MessageActive = false;
		Debug.Log("end dialogue");
	}

	public void aparecer()
	{
		animator.SetBool("IsOpen", true);
	}



}
