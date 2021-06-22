using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text speaker;
    public TMP_Text narration;
    public TMP_Text response;
    public TMP_Text instruction;
    public Button closeBtn;
    public GameObject Dialogue0Canvas;

    public Dialogue dialogue;
    
    
    void Start()
    {
        UpdateTexts();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (dialogue.choice.Length >= 1)
            {
                dialogue = dialogue.choice[(1 - 1)].NextDialogue;
                UpdateTexts();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (dialogue.choice.Length >= 2)
            {
                dialogue = dialogue.choice[(2 - 1)].NextDialogue;
                UpdateTexts();
            }
        }
        if (dialogue.choice.Length == 0)
        {
            closeBtn.gameObject.SetActive(true);
        }
    }

    void UpdateTexts()
    {
        speaker.text = dialogue.speaker;
        narration.text = dialogue.narration;
        response.text = "";
        instruction.text = "Please press ";
        for (int i = 0; i < dialogue.choice.Length; i++)
        {
            response.text += "Choice " + (i + 1).ToString() + ": " + dialogue.choice[i].lines + "\n";
            instruction.text += (i + 1).ToString();
            if (i != dialogue.choice.Length - 1)
                instruction.text += " or ";
        }
        if (dialogue.choice.Length >= 1)
            instruction.text += " to select that choice.";
        else
            instruction.text += " close button.";
    }

    public void CloseDialogueCanvas()
    {
        Dialogue0Canvas.SetActive(false);
    }

}
