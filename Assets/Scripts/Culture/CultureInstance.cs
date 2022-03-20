using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultureInstance : MonoBehaviour
{
    public float progession = 0f;

    public Inventory _inventory;

    public void Sell(int price)
    {
        _inventory.Money += price;
    }
}
