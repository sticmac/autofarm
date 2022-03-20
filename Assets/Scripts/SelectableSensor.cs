using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableSensor : MonoBehaviour
{
    [SerializeField] SpriteRenderer _selectableSprite;

    public void MakeSelectable(bool selectable) {
        _selectableSprite.enabled = selectable;
    }
}
