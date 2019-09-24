using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    public int current;
    public int max;
    public int critical;

    public bool IsCritical()
    {
        if (current <= critical)
        {
            return true;
        }
        return false;
    }
}
