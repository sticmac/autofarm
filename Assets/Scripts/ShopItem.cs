using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Inventory _inventory;

    private Inventory.ItemType _type;
    private int _price;

    public void UpdateText(string name, int price, Inventory.ItemType type)
    {
        _name.text = name;
        _priceText.text = price.ToString() + "€";
        _type = type;
        _price = price;
    }

    public void Buy()
    {
        if (_inventory.Money >= _price)
        {
            _inventory.AddItem(_type, 1);
            _inventory.Money -= _price;
        }
    }
}
