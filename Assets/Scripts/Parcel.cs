using System;
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

    public float HumidityLosePerSeconds;

    private Culture Plante;
    private Sensor HumiditySensor;
    private Actuator Actionneur;
    private SpriteRenderer _background;
    private SpriteRenderer _sprite;

    private float _humidity = 50;

    private int _id;

    public int Id {
        get => _id;
        set => _id = value;
    }

    public void Add()
    {
        if (_sprite != null) { return; }

        gameObject.AddComponent<BoxCollider2D>();

        GameObject go = new GameObject("background");
        go.transform.SetParent(transform, false);
        _background = go.AddComponent<SpriteRenderer>();
        _background.sortingOrder = -1;
        _sprite = gameObject.AddComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _humidity -= HumidityLosePerSeconds * Time.deltaTime;
    }

    public void UpdateSensor(HumiditySensorView _sensorView)
    {
        if (HumiditySensor)
        {
            _sensorView.ActivateSensor();
            _sensorView.UpdateValeur(_humidity);
        } else
        {
            _sensorView.DesactivateSensor();
        }
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
        GameObject actuatorInstance = Instantiate(pActionneur.ActuatorPrefab);
        actuatorInstance.transform.SetParent(transform, false);
        Type = Types.Actioneur;
    }

    public void AddItem(Item pItem) {
        Type t = pItem.GetType();
        if (t == typeof(Culture)) {
            AddCulture(pItem as Culture);
        } else if (t == typeof(Sensor)) {
            AddHumiditySensor(pItem as Sensor); // ooof
        } else if (t == typeof(Actuator)) {
            AddActuator(pItem as Actuator);
        }
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
