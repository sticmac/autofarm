using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] Item _item;
    [SerializeField] ItemPlacer _itemPlacer;
    [SerializeField] Button _button;
    [SerializeField] GameObject _itemObject;

    private UnityAction _action;

    private void Reset() {
        _itemPlacer = transform.GetComponentInParent<ItemPlacer>();
        _button = GetComponent<Button>();
    }

    private void OnEnable() {
        _action = () => _itemPlacer.ActivatePlacementModeForItem(_itemObject, _item);
        _button.onClick.AddListener(_action);
    }

    private void OnDisable() {
        _button.onClick.RemoveListener(_action);
        _action = null;
    }
}
