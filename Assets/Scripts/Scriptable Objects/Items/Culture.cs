using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Culture", menuName = "Culture", order = 0)]
public class Culture : Item 
{
    public float minWater;
    public float maxWater;

    public int SellingPrice;

    public Sprite baseBackground;
    public Sprite baseSprite;
    public Sprite miSprite;
    public Sprite finalSprite;

    [SerializeField] GameObject _actuatorPrefab;
    public GameObject ActuatorPrefab => _actuatorPrefab;
}
