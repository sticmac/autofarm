using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActuatorBehaviour
{
    public List<Rule> Rules;
    public bool Activated;

    public ActuatorBehaviour()
    {
        Activated = false;
    }

    public void SearchAction()
    {
        foreach (var rule in Rules)
        {
            if (rule.verifyRule())
            {
                if (rule.action == Rule.Actions.Activate)
                {
                    if (Activated) { return; }
                    Activate();
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
