using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] Inventory _inventory;

    [Header("Inventory Item UI")]
    [SerializeField] TMPro.TMP_Text _money;

    private void Update() {
        _money.text = _inventory.Money.ToString();
    }
}
