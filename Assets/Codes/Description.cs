using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Description : MonoBehaviour
{
    public Dialogue dialogue;
    public Image sombra1;
    public Image sombra2;
    private DialogueManager dialogueManager;
    private int Green=0;
    private bool lookingAtObject = true;
    private bool Flashingln = true;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.aparecer();
        dialogueManager.StartDialogue(dialogue.DialogoDescripcion);
    }
    private void Update()
    {
        FlashingImage(sombra1);
        FlashingImage(sombra2);
        StopAllCoroutines();
    }

    #region ObjectsFlashing
    public void FlashingImage(Image image)
    {
        image.color=new Color32((byte)0, (byte)Green, (byte)0, 60);
        StartCoroutine(FlashObject());
    }
    IEnumerator FlashObject()
    {
        while (lookingAtObject)
        {
            if (Flashingln)
            {
                if (Green <= 30)
                {
                    Flashingln = false;
                }
                else
                {
                    Green -= 2;
                }
            }
            else
            {
                if (Green >= 250)
                {
                    Flashingln = true;
                }
                else
                {
                    Green += 2;
                }
            }
            new WaitForSeconds(2f);
            yield return new WaitForSeconds(2f);
        }
    }

    #endregion

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Previous()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
