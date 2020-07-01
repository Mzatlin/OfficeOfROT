using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueOptionMenu : WriterBase
{
    [SerializeField]
    List<Button> buttonOptions = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        //  buttonOptions = new List<Button>();
        dialogCanvas.enabled = false;
        dialogue.OnMenuWrite += HandleWrite;
    }

    void HideButtons()
    {
        foreach (Button button in buttonOptions)
        {
            button.enabled = false;
        }
    }

    void EnableOptions()
    {
        for (int i = 0; i < dialogue.currentDialogue.options.Capacity; i++)
        {
            buttonOptions[i].GetComponentInChildren<TextMeshProUGUI>().text = dialogue.currentDialogue.options[i].description;
            buttonOptions[i].enabled = true;
        }
    }

    private void HandleWrite()
    {
        HideButtons();
        EnableOptions();
        textName.text = dialogue.currentDialogue.name;
        dialogCanvas.enabled = true;
        WriteDialogue();
    }

    protected override void WriteDialogue()
    {
        base.WriteDialogue();

        StartCoroutine(TypeLine(dialogue.currentDialogue.sentences[0]));
    }

    public void LoadButton(Button button)
    {
        dialogue.SetupDialougeWriter(GetDialogSO(button.GetComponentInChildren<TextMeshProUGUI>().text));
        EndDialogue();
        
    }

    DialogSO GetDialogSO(string text)
    {
        foreach (DialogOptionSO option in dialogue.currentDialogue.options)
        {
            if (option.description == text)
            {
                return option.dialogue;
            }
        }
        return null;
   
    }

    protected override void EndDialogue()
    {
        if (dialogue.currentDialogue.options.Capacity <= 1)
        {
            dialogCanvas.enabled = false;
        }

      //  base.EndDialogue();
    }

}
