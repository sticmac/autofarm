using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actuator
{
    public string Name;
    public List<Rule> Rules;
    public bool _activated;

    public Actuator(string name)
    {
        Name = name;
        _activated = false;
    }

    public void SearchAction()
    {
        if (_activated) { return; }
        foreach (var rule in Rules)
        {
            if (rule.verifyRule())
            {
                if (rule.action == Rule.Actions.Activate)
                {
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
        _activated = true;
    }

    public virtual void Desactivate()
    {
        _activated = false;
    }
}
