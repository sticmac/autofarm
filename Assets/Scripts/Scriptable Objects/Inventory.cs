using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    private Dictionary<Item, int> _inventory;
    public int Money;

    private void OnEnable() {
        _inventory = new Dictionary<Item, int>();
    }

    public void Clear() {
        _inventory.Clear();
    }

    public void AddItem(Item type, int amount) {
        if (!_inventory.ContainsKey(type)) {
            _inventory.Add(type, amount);
        } else {
            _inventory[type] += amount;
        }
    }

    // Returns the amount of items effectively removed
    public int RemoveItem(Item type, int amount) {
        if (_inventory.ContainsKey(type)) {
            if (_inventory[type] - amount > 0) {
                _inventory[type] -= amount;
                return amount;
            } else {
                int invAmount = _inventory[type];
                _inventory.Remove(type);
                return invAmount;
            }
        } else {
            return 0;
        }
    }

    public void RemoveSingleItem(Item type) {
        RemoveItem(type, 1);
    }

    public int GetItemAmount(Item type) {
        return _inventory.ContainsKey(type) ? _inventory[type] : 0;
    }

}
