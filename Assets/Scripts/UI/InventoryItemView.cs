using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour {
    [SerializeField] Inventory _inventory;
    [SerializeField] Item _item;

    [Space(5)]
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _count;
    [SerializeField] Image _icon;

    public void UpdateView() {
        int count = _inventory.GetItemAmount(_item);
        if (count == 0) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
            _icon.sprite = _item.Icon;
            _count.text = count.ToString();
        }
    }
}