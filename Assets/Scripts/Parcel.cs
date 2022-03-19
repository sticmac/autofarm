using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel
{
    public enum Types
    {
        None,
        Culture,
        Actioneur
    }
    public Types Type;

    private Culture Plante;
    private Sensor HumiditySensor;
    private Actuator Actionneur;

    public Parcel()
    {
        Type = Types.None;
    }

    public void AddCulture(Culture pPlante)
    {
        Plante = pPlante;
        Type = Types.Culture;
    }

    public void AddHumiditySensor(Sensor pHumiditySensor)
    {
        HumiditySensor = pHumiditySensor;
    }

    public void AddActuator(Actuator pActionneur)
    {
        Actionneur = pActionneur;
        Type = Types.Actioneur;
    }

    public void TearOut()
    {
        Plante = null;
        Actionneur = null;
        Type = Types.None;
    }

    public string GetName()
    {
        switch (Type)
        {
            case Types.Actioneur:
                return Actionneur.Name;
            case Types.Culture:
                return Plante.Name;
        }
        return "None";
    }
}
