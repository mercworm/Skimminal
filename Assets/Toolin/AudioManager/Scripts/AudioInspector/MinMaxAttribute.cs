using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxAttribute : PropertyAttribute
{
    public float minLimit = 0;
    public float maxLimit = 1;
    public bool ShowEditRange;
    public bool ShowDebugValues;

    public MinMaxAttribute(int min, int max)
    {
        minLimit = min;
        maxLimit = max;
    }

}
