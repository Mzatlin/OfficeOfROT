using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImageOnCertainDay : MonoBehaviour
{
    public DayTrackerSO day;
    [SerializeField]
    Image finalImage;
    [SerializeField]
    int intendedDay = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (finalImage != null)
        {
            SetImage();
        }
    }

    void SetImage()
    {
        if(day != null && day.currentDay == intendedDay)
        {
            finalImage.enabled = true;
        }
        else
        {
            finalImage.enabled = false;
        }
    }
}
