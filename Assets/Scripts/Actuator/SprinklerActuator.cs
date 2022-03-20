using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerActuator : ActuatorInstance
{
    private Coroutine _coroutine;

    public override void Activate()
    {
        base.Activate();
        _coroutine = StartCoroutine(Sprinkle());
    }

    private IEnumerator Sprinkle()
    {
        while (true)
        {
            parcel.Sprinkle();
            yield return null;
        }
    }

    public override void Desactivate()
    {
        base.Desactivate();
        StopCoroutine(_coroutine);
    }
}