﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueOptionMenu : WriterBase
{
  
    public List<Button> buttonOptions = new List<Button>();
    public GameObject mainDialogueCanvas;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        dialogCanvas.enabled = false;
        dialogue.OnMenuWrite += HandleWrite;
        HideButtons();
    }

    void HideButtons()
    {
        if(buttonOptions != null && buttonOptions.Capacity > 0)
        {
            foreach (Button button in buttonOptions)
            {
                if(button != null)
                {
                    button.enabled = false;
                    button.gameObject.SetActive(false);
                    button.interactable = false;
                }
            }
        }
    }

    void EnableOptions()
    {
        for (int i = 0; i < dialogue.currentDialogue.options.Capacity; i++)
        {
            var button = buttonOptions[i];
            if(button != null)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.currentDialogue.options[i].description;
                button.enabled = true;
                button.gameObject.SetActive(true);
                button.interactable = true;
            }

        }
    }

    private void HandleWrite()
    {
        if(mainDialogueCanvas != null && mainDialogueCanvas.activeInHierarchy)
        {
            mainDialogueCanvas.SetActive(false);
        }
        HideButtons();
        EnableOptions();
        textName.text = dialogue.currentDialogue.name1;
        if(dialogCanvas != null)
        {
            dialogCanvas.enabled = true;
            WriteDialogue();
        }
    }

    protected override void WriteDialogue()
    {
        base.WriteDialogue();

        StartCoroutine(TypeLine(dialogue.currentDialogue.sentences[0]));
    }

    public void LoadButton(Button button)
    {
        if (mainDialogueCanvas != null)
        {
            mainDialogueCanvas.SetActive(true);
        }
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
