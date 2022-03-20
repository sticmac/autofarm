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
    private CultureInstance PlanteInstance;
    private SensorInstance HumiditySensor;
    private Actuator Actionneur;
    private ActuatorInstance ActionneurInstance;
    private SpriteRenderer _background;
    private SpriteRenderer _sprite;

    private float _humidity = 100;

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
        ProgressCulture();
    }

    public void Sprinkle()
    {
        _humidity += HumidityLosePerSeconds * Time.deltaTime * 2;
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
        AudioManager.Instance.Play("Planter");
        Plante = pPlante;
        _background.sprite = Plante.baseBackground;
        _sprite.sprite = Plante.baseSprite;
        GameObject cultureInsance = Instantiate(pPlante.ActuatorPrefab);
        cultureInsance.transform.SetParent(transform, false);
        PlanteInstance = cultureInsance.GetComponent<CultureInstance>();
        Type = Types.Culture;
    }

    public void ProgressCulture()
    {
        if (Type != Types.Culture) { return; }

        if (_humidity >= Plante.minWater && _humidity <= Plante.maxWater)
            PlanteInstance.progession += Time.deltaTime * 10/3;
        if (PlanteInstance.progession >= 33)
        {
            _sprite.sprite = Plante.miSprite;
        }
        if (PlanteInstance.progession >= 66)
        {
            _sprite.sprite = Plante.finalSprite;
        }
        if (PlanteInstance.progession >= 100)
        {
            PlanteInstance.Sell(Plante.SellingPrice);
            TearOut();
        }
    }

    public void AddHumiditySensor(Sensor pHumiditySensor)
    {
        Add();
        AudioManager.Instance.Play("Actuator");
        GameObject sensorInstance = Instantiate(pHumiditySensor.ActuatorPrefab);
        sensorInstance.transform.SetParent(transform, false);
        HumiditySensor = sensorInstance.GetComponent<SensorInstance>();
    }

    public void AddActuator(Actuator pActionneur)
    {
        Add();
        AudioManager.Instance.Play("Actuator");
        Actionneur = pActionneur;
        GameObject actuatorInstance = Instantiate(pActionneur.ActuatorPrefab);
        actuatorInstance.transform.SetParent(transform, false);
        ActionneurInstance = actuatorInstance.GetComponent<ActuatorInstance>();
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
        AudioManager.Instance.Play("Tear Out");
        Plante = null;
        Actionneur = null;
        Type = Types.None;
        if (ActionneurInstance)
            Destroy(ActionneurInstance.gameObject);
        if (PlanteInstance)
            Destroy(PlanteInstance.gameObject);
        _sprite.sprite = null;
        _background.sprite = null;
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
