using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Culture", menuName = "Culture", order = 0)]
public class Culture : Item 
{
    public float minWater;
    public float maxWater;

    public Sprite baseBackground;
    public Sprite baseSprite;

    public void ConfigureWaterNeeded(float min, float max)
    {
        minWater = min;
        maxWater = max;
    }
}
