using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DayLookupBase : MonoBehaviour
{
    [SerializeField]
    protected DayTrackerSO day;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        LookupItem(day.currentDay);
    }

    protected void LookupItem(int index)
    {
        if (index > 0 && index <= day.maxDay)
        {
            SetItem(index);
        }
    }

    protected abstract void SetItem(int index);
}
