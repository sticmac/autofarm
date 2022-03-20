using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActuatorInstance : MonoBehaviour
{
    public List<Rule> Rules;
    public bool Activated;
    public Parcel parcel;

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
                        parcel = rule.sensor.gameObject.GetComponentInParent<Parcel>();
                    }
                } else
                {
                    Desactivate();
                    parcel = null;
                }
                return;
            }
        }
    }

    public Rule CreateNewRule() {
        Rule rule = new Rule();
        Rules.Add(rule);
        return rule;
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
