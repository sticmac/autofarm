using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItemView : MonoBehaviour {
    [SerializeField] Inventory _inventory;
    [SerializeField] Item _item;

    [Space(5)]
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _count;

    public void UpdateView() {
        int count = _inventory.GetItemAmount(_item);
        if (count == 0) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
            _count.text = count.ToString();
        }
    }
}