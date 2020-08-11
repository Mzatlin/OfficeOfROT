using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementDayOnStart : MonoBehaviour
{
    public DayTrackerSO day;
    // Start is called before the first frame update
    void Start()
    {
        IncrementDay();
    }


    private void IncrementDay()
    {
        day.IncrementDay();
    }
}
