using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid info")]
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [Header("Canvas")]
    [SerializeField] private GameObject _parcelInfo;

    private List<Parcel> _lstParcel;
    private Parcel _currentParcel;

    void Start()
    {
        CreateGrid();

        _parcelInfo.gameObject.SetActive(false);
    }

    private void CreateGrid()
    {
        _lstParcel = new List<Parcel>();

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _lstParcel.Add(new Parcel());
            }
        }
    }

    void Update()
    {
        
    }

    void SelectParcel(int id)
    {
        _currentParcel = _lstParcel[id];

        _parcelInfo.gameObject.SetActive(true);
    }
}
