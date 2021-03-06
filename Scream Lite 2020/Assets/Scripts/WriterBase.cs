﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriterBase : MonoBehaviour
{

    [SerializeField]
    protected float typeSpeed = 3f;
    public TextMeshProUGUI textDialog;
    public Canvas dialogCanvas;
    public DialogueLoader dialogue;
    public TextMeshProUGUI textName;
    protected bool isCreated = false;

    protected virtual void Awake()
    {

        dialogCanvas.enabled = false;
        //dialogue.OnWrite += HandleWrite;
    }


    protected IEnumerator TypeLine(string line)
    {
        foreach (char letter in line)
        {
            textDialog.text += letter;
            yield return new WaitForSeconds(typeSpeed * Time.deltaTime);
        }

    }

    protected virtual void WriteDialogue()
    {
        textDialog.text = "";

    }

    protected virtual void OnDestroy()
    {
        StopAllCoroutines();
    }

    protected virtual void EndDialogue()
    {
        dialogCanvas.enabled = false;
        dialogue.EndDialougeWriter();
    }
}
