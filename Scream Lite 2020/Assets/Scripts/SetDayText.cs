using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetDayText : DayLookupBase
{
    [TextArea(3,5)]
    public List<string> textItems = new List<string>();
    [SerializeField]
    TextMeshProUGUI currentText;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void SetItem(int index)
    {
        if(textItems[index-1] != null)
        {
            currentText.text = textItems[index-1];
        }
    }
}
