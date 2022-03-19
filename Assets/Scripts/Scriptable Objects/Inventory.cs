using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    public enum ItemType {
        Wheat,
        HumiditySensor,
        Alarm,
        Sprinkler
    }

    private Dictionary<ItemType, int> _inventory;
    public int Money;

    private void OnEnable() {
        _inventory = new Dictionary<ItemType, int>();
        _inventory.Add(ItemType.Wheat, 3);
        Money = 30;
    }

    public void Clear() {
        _inventory.Clear();
    }

    public void AddItem(ItemType type, int amount) {
        if (!_inventory.ContainsKey(type)) {
            _inventory.Add(type, amount);
        } else {
            _inventory[type] += amount;
        }
    }

    // Returns the amount of items effectively removed
    public int RemoveItem(ItemType type, int amount) {
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

    public int GetItemAmount(ItemType type) {
        return _inventory.ContainsKey(type) ? _inventory[type] : 0;
    }

}
