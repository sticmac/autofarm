using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItemView : MonoBehaviour {
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _count;

    public void UpdateInfo(int count) {
        if (count == 0) {
            gameObject.SetActive(false);
        } else {
            _count.text = count.ToString();
        }
    }
}