using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmActuator : ActuatorInstance {
    [SerializeField] GridManager _gridManager;

    private void Start() {
    }

    public override void Activate()
    {
        base.Activate();
        
    }

    public override void Desactivate()
    {
        base.Desactivate();

    }
}