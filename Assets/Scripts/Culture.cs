using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culture
{
    public string Name;
    public float minWater;
    public float maxWater;

    public Culture(string name)
    {
        Name = name;
    }

    public void ConfigureWaterNeeded(float min, float max)
    {
        minWater = min;
        maxWater = max;
    }
}
