using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PanelController : MonoBehaviour
{

    public Camera PanelCamera;
    public GameObject Panel1;
    public GameObject Panel2;
    private DialogueSimple dialogueManager;
    public Dialogue dialogue;

    private bool lookingAtObject = false;
    private bool Flashingln = true;
    private GameObject touchedObject;
    private int Green;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        dialogueManager = FindObjectOfType<DialogueSimple>();
        dialogueManager.StartDialogue(dialogue.DialogoPanel);
        int Diagram = PlayerPrefs.GetInt("diagram");
        switch (Diagram)
        {
            case 1:
                {
                    Panel1.SetActive(true);
                    Panel2.SetActive(false);
                    break;
                }
            case 2:
                {
                    Panel1.SetActive(false);
                    Panel2.SetActive(true);
                    break;
                }
            default:
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (touchedObject != null)
        {
            FlashingObject(touchedObject);
        }
    }


    #region ObjectsFlashing
    public void FlashingObject(GameObject touchedObject)
    {
        lookingAtObject = true;
        touchedObject.GetComponent<Renderer>().material.color = new Color32(0, (byte)Green, 0, 255); 
        StartCoroutine(FlashObject());
        StopAllCoroutines();
    }
    IEnumerator FlashObject()
    {
        while (lookingAtObject)
        {
            if (Flashingln)
            {
                if (Green <= 10)
                {
                    Flashingln = false;
                }
                else
                {
                    Green -= 5;
                    yield return new WaitForSeconds(2f);
                }
            }
            else
            {
                if (Green >= 150)
                {
                    Flashingln = true;
                }
                else
                {
                    Green += 5;
                    yield return new WaitForSeconds(2f);
                }
            }
        }
    }
    public void StopFlashing()
    {
        if (touchedObject != null)
        {
            lookingAtObject = false;
            touchedObject.GetComponent<Renderer>().material.color = new Color32(0, 0, 255, 255);
            StopAllCoroutines();
        }  
    }
    #endregion
    public void CheckTouchedElement(string txtTouchedObject)
    {
        source.Play();
        lookingAtObject = false;
        StopFlashing();
        switch (txtTouchedObject)
        {
            case "PAT1":
                dialogueManager.StartDialogue(dialogue.DialogoPAT1);
                break;
            case "BN1":
                dialogueManager.StartDialogue(dialogue.DialogoBN1);
                break;
            case "CMC1":
                dialogueManager.StartDialogue(dialogue.DialogoCMC1);
                break;
            case "W1":
                dialogueManager.StartDialogue(dialogue.DialogoW1);
                break;
            case "V1":
                dialogueManager.StartDialogue(dialogue.DialogoV1);
                break;
            case "U1":
                dialogueManager.StartDialogue(dialogue.DialogoU1);
                break;
            case "BR1":
                dialogueManager.StartDialogue(dialogue.DialogoBR1);
                break;
            case "PAT2":
                dialogueManager.StartDialogue(dialogue.DialogoPAT2);
                break;

            case "NVC1":
                dialogueManager.StartDialogue(dialogue.DialogoNVC1);
                break;
            case "PVC1":
                dialogueManager.StartDialogue(dialogue.DialogoPVC1);
                break;
            case "LO1":
                dialogueManager.StartDialogue(dialogue.DialogoLO1);
                break;
            case "LO2":
                dialogueManager.StartDialogue(dialogue.DialogoLO2);
                break;

            case "CMC2":
                dialogueManager.StartDialogue(dialogue.DialogoCMC2);
                break;
            case "W2":
                dialogueManager.StartDialogue(dialogue.DialogoW2);
                break;
            case "V2":
                dialogueManager.StartDialogue(dialogue.DialogoV2);
                break;
            case "U2":
                dialogueManager.StartDialogue(dialogue.DialogoU2);
                break;

            case "BR2":
                dialogueManager.StartDialogue(dialogue.DialogoBR2);
                break;
            case "BN2":
                dialogueManager.StartDialogue(dialogue.DialogoBN2);
                break;
            case "LI1":
                dialogueManager.StartDialogue(dialogue.DialogoLI1);
                break;
            case "LI2":
                dialogueManager.StartDialogue(dialogue.DialogoLI2);
                break;
            case "NVC2":
                dialogueManager.StartDialogue(dialogue.DialogoNVC2);
                break;
            case "PVC2":
                dialogueManager.StartDialogue(dialogue.DialogoPVC2);
                break;
        }
        touchedObject=GameObject.Find("Term"+txtTouchedObject);

        float z = touchedObject.transform.position.z;
        float x = touchedObject.transform.position.x;
        Vector3 newPosition = new Vector3(x,5,z);
        PanelCamera.transform.position= newPosition;
    }
    public void Previous()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PlayerPrefs.SetInt("auxBack", 1);
    }

}
