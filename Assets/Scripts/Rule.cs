using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule
{
    public enum LogicalOperators
    {
        Egal,
        Inf,
        Sup
    }

    public enum Actions
    {
        Activate,
        Desactivate
    }

    public int value;
    public Sensor sensor;
    public LogicalOperators logicalOperator;
    public Actions action;

    public bool verifyRule()
    {
        bool conditionVerifiee = false;
        switch (logicalOperator)
        {
            case LogicalOperators.Egal:
                if (sensor.Value == value)
                {
                    conditionVerifiee = true;
                }
                break;
            case LogicalOperators.Sup:
                if (sensor.Value > value)
                {
                    conditionVerifiee = true;
                }
                break;
            case LogicalOperators.Inf:
                if (sensor.Value < value)
                {
                    conditionVerifiee = true;
                }
                break;
        }
        return conditionVerifiee;
    }
}
