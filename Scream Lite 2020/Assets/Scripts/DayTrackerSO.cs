using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DayTracker")]
public class DayTrackerSO : ScriptableObject
{
    public int currentDay;
    public int maxDay = 3;

    public void IncrementDay()
    {
        if(currentDay == maxDay)
        {
            currentDay = 1;
        }
        else
        {
            currentDay++;
        }
    }
}
