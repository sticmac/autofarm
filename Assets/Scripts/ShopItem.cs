using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;

    public void UpdateText(string name, int price)
    {
        _name.text = name;
        _price.text = price.ToString() + "€";
    }
}
