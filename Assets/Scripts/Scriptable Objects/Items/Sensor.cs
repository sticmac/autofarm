using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sensor", menuName = "Sensor", order = 0)]
public class Sensor : Item
{
    [SerializeField] GameObject _actuatorPrefab;

    public GameObject ActuatorPrefab => _actuatorPrefab;
} 
