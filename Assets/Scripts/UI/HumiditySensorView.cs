using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HumiditySensorView : MonoBehaviour
{
    [SerializeField] private TMP_Text _valeurText;
    [SerializeField] private Image _icon;

    public void UpdateValeur(float valeur)
    {
        _valeurText.text = Mathf.FloorToInt(valeur).ToString();
    }

    public void ActivateSensor()
    {
        _icon.color = Color.white;
    }

    public void DesactivateSensor()
    {
        _icon.color = Color.gray;
        _valeurText.text = "";
    }
}
