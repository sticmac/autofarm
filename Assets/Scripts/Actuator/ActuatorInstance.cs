using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActuatorInstance : MonoBehaviour
{
    public List<Rule> Rules;
    public bool Activated;

    public void SearchAction()
    {
        foreach (var rule in Rules)
        {
            if (rule.verifyRule())
            {
                if (rule.action == Rule.Actions.Activate)
                {
                    if (!Activated) { 
                        Activate();
                    }
                } else
                {
                    Desactivate();
                }
                return;
            }
        }
    }

    public virtual void Activate()
    {
        Activated = true;
    }

    public virtual void Desactivate()
    {
        Activated = false;
    }
}
