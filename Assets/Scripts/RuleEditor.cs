using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleEditor : MonoBehaviour
{
    private Rule _rule;

    public Rule Rule {
        set => _rule = value;
    }

    public void SetRuleOperator(Rule.LogicalOperators op) {
        _rule.logicalOperator = op;
    }

    public void SetValue(string textValue) {
        try {
            int value = int.Parse(textValue);
            _rule.value = value;
        } catch (ArgumentException e) {
            Debug.Log(textValue + " is not a number");
        }
    }

    public void SetSensor(SensorInstance sensorInstance) {
        _rule.sensor = sensorInstance;
    }
}
