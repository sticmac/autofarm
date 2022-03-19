using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInit : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] Inventory _inventory;
    [SerializeField] Item _wheat;

    [Header("Parameters")]
    [SerializeField] int _wheatAmount;
    [SerializeField] int _moneyAmount;

    private void Start() {
        _inventory.Clear();
        _inventory.Money = _moneyAmount;
        _inventory.AddItem(_wheat, _wheatAmount);
    }
}
