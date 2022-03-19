using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParcelCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text _title;

    public string Title { get; set; }

    private void OnEnable()
    {
        _title.text = Title;
    }
}
