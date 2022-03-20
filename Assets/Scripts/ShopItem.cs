using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Inventory _inventory;

    private Item _item;

    public void Init(Item item)
    {
        _item = item;
        _name.text = item.Name;
        _priceText.text = item.Price.ToString() + "€";
    }

    public void Buy()
    {
        if (_inventory.Money >= _item.Price)
        {
            _inventory.AddItem(_item, 1);
            _inventory.Money -= _item.Price;
        }
    }
}
