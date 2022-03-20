using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Actuator", menuName = "Actuator", order = 0)]
public class Actuator : Item
{
    [SerializeField] GameObject _actuatorPrefab;

    public GameObject ActuatorPrefab => _actuatorPrefab;
}
