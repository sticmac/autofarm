using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actuator
{
    public string Name;

    public Actuator(string name)
    {
        Name = name;
    }

    public virtual void Activate()
    {

    }

    public virtual void Desactivate()
    {

    }
}
