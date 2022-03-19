using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel : MonoBehaviour
{
    public enum Types
    {
        None,
        Culture,
        Actioneur
    }
    public Types Type = Types.None;

    private Culture Plante;
    private Sensor HumiditySensor;
    private Actuator Actionneur;
    private SpriteRenderer _background;
    private SpriteRenderer _sprite;

    public void Add()
    {
        gameObject.AddComponent<BoxCollider2D>();

        GameObject go = new GameObject("background");
        go.transform.SetParent(transform, false);
        _background = go.AddComponent<SpriteRenderer>();
        _background.sortingOrder = -1;
        _sprite = gameObject.AddComponent<SpriteRenderer>();
    }

    public void AddCulture(Culture pPlante)
    {
        Add();
        Plante = pPlante;
        _background.sprite = Plante.baseBackground;
        _sprite.sprite = Plante.baseSprite;
        Type = Types.Culture;
    }

    public void AddHumiditySensor(Sensor pHumiditySensor)
    {
        Add();
        HumiditySensor = pHumiditySensor;
    }

    public void AddActuator(Actuator pActionneur)
    {
        Add();
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
