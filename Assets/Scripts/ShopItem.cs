using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Inventory _inventory;

    private Inventory.ItemType _type;

    public void UpdateText(string name, int price, Inventory.ItemType type)
    {
        _name.text = name;
        _price.text = price.ToString() + "€";
        _type = type;
    }

    public void Buy()
    {
        _inventory.AddItem(_type, 1);
    }
}
