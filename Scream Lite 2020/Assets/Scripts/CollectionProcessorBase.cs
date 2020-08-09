using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectionProcessorBase : MonoBehaviour
{
    protected int index = 0;

    protected virtual void IterateListByOne<T>(List<T> myList)
    {
        if (myList.Capacity > 0)
        {
            if (index > myList.Capacity - 1)
            {
                index = 0;
            }
            UseItemInList(index);
            index++;
        }
    }

    protected abstract void UseItemInList(int index);

}
