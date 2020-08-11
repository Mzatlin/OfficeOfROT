using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDayOnClick : MonoBehaviour
{
    public DayTrackerSO day;
    
    public void OnClick()
    {
        if(day != null)
        {
            day.currentDay = 1;
        }
    }
}
