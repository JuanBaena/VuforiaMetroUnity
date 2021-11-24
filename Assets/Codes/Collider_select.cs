using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Timeline;

public class Collider_select : MonoBehaviour
{
    #region UnityObjetcs
    public GameObject sound;
    public GameObject water;
    public GameObject dust;
    public GameObject train;
    public GameObject buildingTrain;
    public GameObject stones;
    public TextMeshProUGUI ButtonNextText;
    public Animator animBtnSiguiente;
    public Animator animPanel;
    public Animator animDiaBox;
    public Dialogue dialogue;
    public Button soundButton;
    public Sprite ON;
    public Sprite OFF;
    private DialogueManager dialogueManager;
    private AudioSource source;
    private GameObject touchedObject;
    #endregion

    #region LocalVariables
    public int fase;
    private bool Upchange = true;
    private bool flancoSubida = true;
    private int Green;
    private int diagramNumber = 0;
    private bool lookingAtObject = false;
    private bool Flashingln = true;
    private bool SoundIsON;
    string txtTouchedObject;
    private Material[] originTouchedMaterials;
    private List<GameObject> selectObjects = new List<GameObject>();
    private List<Color32> originTouchedColors = new List<Color32>();
    #endregion

    void Start()
    {
        Debug.Log("empezamos");
        source = GetComponent<AudioSource>();
        sound.SetActive(false);
        water.SetActive(false);
        dust.SetActive(false);
        train.SetActive(false);
        buildingTrain.SetActive(false);
        stones.SetActive(false);
        SoundIsON = true;
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.aparecer();
        int auxBack = PlayerPrefs.GetInt("auxBack");
        if (auxBack == 1) fase = 6; else fase = 0;

    }

    void Update()
    {
        if (flancoSubida)
        {
            switch (fase)
            {
                case 0:
                    {
                        dialogueManager.StartDialogue(dialogue.DialogoInicioAR);
                        if (!Upchange)
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                        }
                        break;
                    }
                case 1:
                    {
                        if (!Upchange) StartCoroutine(DeactivateAnimation(dust));

                        dialogueManager.StartDialogue(dialogue.DialogoNormas);
                        ActivateAnimation(train);
                        ActivateAnimation(buildingTrain);
                        break;
                    }
                case 2:
                    {
                        StartCoroutine(DeactivateAnimation(train));
                        StartCoroutine(DeactivateAnimation(buildingTrain));
                        if (!Upchange) StartCoroutine(DeactivateAnimation(water));

                        dialogueManager.StartDialogue(dialogue.DialogoProtecciónIP6X);
                        ActivateAnimation(dust);
                        break;
                    }
                case 3:
                    {
                        if (!Upchange) StartCoroutine(DeactivateAnimation(stones));
                        StartCoroutine(DeactivateAnimation(dust));

                        ActivateAnimation(water);
                        dialogueManager.StartDialogue(dialogue.DialogoProtecciónEstanco);
                        break;
                    }
                case 4:
                    {
                        StartCoroutine(DeactivateAnimation(water));
                        if (!Upchange) StartCoroutine(DeactivateAnimation(sound));

                        ActivateAnimation(stones);
                        dialogueManager.StartDialogue(dialogue.DialogoProtecciónIP2X);
                        break;
                    }
                case 5:
                    {
                        StartCoroutine(DeactivateAnimation(stones));
                        dialogueManager.TouchesDialogues = false;
                        animPanel.SetBool("ScrollOpen", false);
                        ButtonAppear();
                        StopFlashing();

                        ActivateAnimation(sound);
                        dialogueManager.StartDialogue(dialogue.DialogoAcústica);
                        ButtonNextText.text = "Siguiente >";
                        break;
                    }
                case 6:
                    {
                        StartCoroutine(DeactivateAnimation(sound));

                        StopFlashing();
                        ButtonNextText.text = "Diagrama";
                        dialogueManager.TouchesDialogues = true;
                        animPanel.SetBool("ScrollOpen", true);
                        break;
                    }
                default:
                    break;
            }
        }

        flancoSubida = false;

        #region Fase6ActiveFunctions
        if (Input.GetMouseButtonDown(0) && fase == 6)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    StopFlashing();
                    touchedObject = hit.transform.gameObject;
                    selectObjects.Add(touchedObject);
                    GetMaterialColors();
                    lookingAtObject = true;
                    CheckTouchedElement(touchedObject);
                }
            }
        }

        if (selectObjects != null && lookingAtObject)
        {
            ButtonAppear();
            foreach (var obj in selectObjects)
            {
                FlashingObject(obj);
            }

        }
        #endregion

    }

    #region ObjectsSelection
    private void CheckTouchedElement(GameObject touchedObject)
    {
        txtTouchedObject = touchedObject.transform.name;
        source.Play();
        switch (txtTouchedObject)
        {
            case "panelElectrico1":
                dialogueManager.StartDialogue(dialogue.DialogoPanelElectrico1);
                diagramNumber = 1;
                break;
            case "panelElectrico2":
                dialogueManager.StartDialogue(dialogue.DialogoPanelElectrico2);
                diagramNumber = 2;
                break;
            case "panelMantenimiento.001":
                dialogueManager.StartDialogue(dialogue.DialogoPanelMantenimiento);
                break;
            case "panelMantenimiento.003":
                dialogueManager.StartDialogue(dialogue.DialogoPanelMantenimiento);
                break;
            case "panelMantenimientoG.001":
                dialogueManager.StartDialogue(dialogue.DialogoPanelMantenimientoG);
                break;
            case "panelMantenimientoGI":
                dialogueManager.StartDialogue(dialogue.DialogoPanelMantenimientoGI);
                break;
            case "ventilador2.001":
                dialogueManager.StartDialogue(dialogue.DialogoVentilador);
                break;
            case "ventilador2.002":
                dialogueManager.StartDialogue(dialogue.DialogoVentilador);
                break;
            case "borneraBAT":
                dialogueManager.StartDialogue(dialogue.DialogoBorneraBat);
                break;
            case "borneraBAT.001":
                dialogueManager.StartDialogue(dialogue.DialogoBorneraBat);
                break;
            case "borneraBAT.002":
                dialogueManager.StartDialogue(dialogue.DialogoBorneraBat);
                break;
            case "borneraAC.001":
                dialogueManager.StartDialogue(dialogue.DialogoBorneraAC);
                break;
            case "groundingGrounding Clamp.001":
                dialogueManager.StartDialogue(dialogue.DialogoPT);
                break;
            case "groundingGrounding Clamp.002":
                dialogueManager.StartDialogue(dialogue.DialogoPT);
                break;
            default:
                break;
        }
    }
    public void CheckPanelButtons(String botontxt)
    {
        StopFlashing();
        lookingAtObject = true;
        source.Play();
        switch (botontxt)
        {
            case "panElec1":
                dialogueManager.StartDialogue(dialogue.DialogoPanelElectrico1);
                selectObjects.Add(GameObject.Find("panelElectrico1"));
                diagramNumber = 1;
                break;
            case "panElec2":
                dialogueManager.StartDialogue(dialogue.DialogoPanelElectrico2);
                selectObjects.Add(GameObject.Find("panelElectrico2"));
                diagramNumber = 2;
                break;
            case "Mant":
                dialogueManager.StartDialogue(dialogue.DialogoMantenimientos);
                selectObjects.Add(GameObject.Find("panelMantenimiento.001"));
                selectObjects.Add(GameObject.Find("panelMantenimiento.003"));
                selectObjects.Add(GameObject.Find("panelMantenimientoG.001"));
                selectObjects.Add(GameObject.Find("panelMantenimientoGI"));
                break;
            case "Vent":
                dialogueManager.StartDialogue(dialogue.DialogoVentiladores);
                selectObjects.Add(GameObject.Find("ventilador2.001"));
                selectObjects.Add(GameObject.Find("ventilador2.002"));
                break;
            case "BornCom":
                dialogueManager.StartDialogue(dialogue.DialogoBorneras);
                selectObjects.Add(GameObject.Find("borneraBAT"));
                selectObjects.Add(GameObject.Find("borneraBAT.001"));
                selectObjects.Add(GameObject.Find("borneraBAT.002"));
                break;
            case "BornCA":
                dialogueManager.StartDialogue(dialogue.DialogoBorneraAC);
                selectObjects.Add(GameObject.Find("borneraAC.001"));
                break;
            case "PTs":
                dialogueManager.StartDialogue(dialogue.DialogoPTs);
                selectObjects.Add(GameObject.Find("groundingGrounding Clamp.001"));
                selectObjects.Add(GameObject.Find("groundingGrounding Clamp.002"));
                break;
            default:
                break;
        }
        GetMaterialColors();
    }
    #endregion

    #region ObjectsFlashing
    public void FlashingObject(GameObject touchedObject)
    {
        originTouchedMaterials = touchedObject.GetComponent<Renderer>().materials;
        foreach (var Mat in originTouchedMaterials)
        {
            Mat.color = new Color32((byte)0, (byte)Green, (byte)0, 255);
            StartCoroutine(FlashObject());
        }
    }
    IEnumerator FlashObject()
    {
        while (lookingAtObject)
        {
            yield return new WaitForSeconds(0.05f);
            if (Flashingln)
            {
                if (Green <= 30)
                {
                    Flashingln = false;
                }
                else
                {
                    Green -= 30;
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
                    Green += 30;
                }
            }
        }
    }
    public void StopFlashing()
    {
        int i = 0;
        diagramNumber = 0;
        if (selectObjects != null)
        {
            foreach (var obj in selectObjects)
            {
                originTouchedMaterials = obj.GetComponent<Renderer>().materials;
                foreach (var Mat in originTouchedMaterials)
                {
                    Mat.color = originTouchedColors[i];
                    i++;
                }
            }
            selectObjects.Clear();
            originTouchedColors.Clear();
            Debug.Log("paramos flashing bebé");
            lookingAtObject = false;
            ButtonDisappear();
            if (fase == 6)
            {
                dialogueManager.StartDialogue(dialogue.DialogoInicioTouch);
            }

        }
    }
    public void GetMaterialColors()
    {
        foreach (var obj in selectObjects)
        {
            originTouchedMaterials = obj.GetComponent<Renderer>().materials;
            foreach (var Mat in originTouchedMaterials)
            {
                originTouchedColors.Add(Mat.color);
            }
        }
    }

    #endregion

    #region ButtonFunctions
    public void countUP()
    {
        if (fase < 6)
        {
            fase++;
            Upchange = true;
            flancoSubida = true;
        }
        else
        {
            if (fase == 6)
            {
                GoToDiagram();
            }
        }
    }
    public void countDOWN()
    {
        if (fase > 0)
        {
            fase--;
            Upchange = false;
            flancoSubida = true;
            animBtnSiguiente.SetBool("IsOpen", true);
        }
    }
    public void ButtonAppear()
    {
        if (fase == 6 && diagramNumber != 0)
        {
            animBtnSiguiente.SetBool("IsOpen", true);
        }
        else
        {
            if (fase != 6)
            {
                animBtnSiguiente.SetBool("IsOpen", true);
            }
            if (fase == 0)
            {
                fase++;
                Upchange = true;
                flancoSubida = true;
            }
        }
    }
    public void ButtonDisappear()
    {
        if (fase == 6)
        {
            animBtnSiguiente.SetBool("IsOpen", false);
        }
    }
    public void GoToDiagram()
    {
        switch (diagramNumber)
        {
            case 1:
                {
                    Debug.Log("Diagrama 1");
                    break;
                }
            case 2:
                {
                    Debug.Log("Diagrama 2");

                    break;
                }
            default:
                break;
        }
        PlayerPrefs.SetInt("diagram", diagramNumber);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SoundConfiguration()
    {
        Image image = soundButton.GetComponent<Image>();
        if (SoundIsON)
        {
            SoundIsON = false;
            image.sprite = OFF;
            AudioListener.pause = true;
        }
        else
        {
            SoundIsON = true;
            image.sprite = ON;
            AudioListener.pause = false;
        }
    }
    #endregion

    #region ActivateDeactivateAnimations
    void ActivateAnimation(GameObject obj)
    {
        obj.SetActive(true);
        Animator anim = obj.GetComponent<Animator>();
        anim.enabled = true;
        AnimatorControllerParameter[] parameters = anim.parameters;
        if (parameters[0].type == AnimatorControllerParameterType.Bool)
            anim.SetBool(parameters[0].name, true);


    }
    //IEnumerator deactivates when a transition is finished
    IEnumerator DeactivateAnimation(GameObject obj)
    {
        if (obj.activeSelf)
        {
            Animator anim = obj.GetComponent<Animator>();
            AnimatorControllerParameter[] parameters = anim.parameters;
            if (parameters[0].type == AnimatorControllerParameterType.Bool)
                anim.SetBool(parameters[0].name, false);
            string s1 = anim.GetCurrentAnimatorClipInfo(0)[0].clip.ToString();
            string s2 = s1;
            while (s2 == s1)
            {
                s2 = anim.GetCurrentAnimatorClipInfo(0)[0].clip.ToString();
                yield return null;
            }
            anim.enabled = false;
            obj.SetActive(false);
            Debug.Log("salimos papá");
        }
    }
    #endregion
}
