using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] Inventory _inventory;

    [Header("Inventory Item UI")]
    [SerializeField] InventoryItemView _wheatView;
    [SerializeField] InventoryItemView _humiditySensorView;
    [SerializeField] InventoryItemView _alarmView;
    [SerializeField] InventoryItemView _sprinklerView;

    private void Start() {
        //_inventory.Clear(); // Eff
    }

    private void Update() {
        _wheatView.UpdateInfo(_inventory.GetItemAmount(Inventory.ItemType.Wheat));
        _humiditySensorView.UpdateInfo(_inventory.GetItemAmount(Inventory.ItemType.HumiditySensor));
        _alarmView.UpdateInfo(_inventory.GetItemAmount(Inventory.ItemType.Alarm));
        _sprinklerView.UpdateInfo(_inventory.GetItemAmount(Inventory.ItemType.Sprinkler));
    }
}
