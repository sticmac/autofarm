using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] InventoryItemView[] _itemViews;

    private void Reset() {
        _itemViews = GetComponentsInChildren<InventoryItemView>();
    }

    private void Update() {
        foreach (InventoryItemView item in _itemViews)
        {
            item.UpdateView();
        }
    }
}
