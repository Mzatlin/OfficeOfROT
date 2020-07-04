using System.Collections;
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
    public DialogProcessorSO dialogue;
    public TextMeshProUGUI textName;

    void Start()
    {
        dialogCanvas.enabled = false;
    }

    protected IEnumerator TypeLine(string line)
    {
        foreach (char letter in line)
        {
            textDialog.text += letter;
            yield return new WaitForSeconds(typeSpeed * Time.deltaTime);
        }

    }

    public void ProcessDialogWrite()
    {
        WriteDialogue();
    }

    protected virtual void WriteDialogue()
    {
        textDialog.text = "";
        StopAllCoroutines();
    }

    protected virtual void EndDialogue()
    {
        dialogCanvas.enabled = false;
        dialogue.EndDialougeWriter();
    }
}
