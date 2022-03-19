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

    [Header("Prefabs")]
    [SerializeField] private GameObject _hoverPrefabs;

    private List<Parcel> _lstParcel;
    private Parcel _currentParcel;

    private GameObject _hover;

    private bool _isParcelSelected { get { return _parcelInfo.gameObject.activeSelf; } }

    void Start()
    {
        CreateGrid();

        _parcelInfo.gameObject.SetActive(false);
        _hover = Instantiate(_parcelInfo.gameObject, transform);
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
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    void OnClick()
    {
        if (_isParcelSelected) { UnSelectParcel(); return; }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < 0 || mousePosition.y < 0 || mousePosition.x >= _width || mousePosition.y >= _height) { return; }

        int id = Mathf.FloorToInt(mousePosition.y) * _width + Mathf.FloorToInt(mousePosition.x);
        SelectParcel(id);
    }

    void SelectParcel(int id)
    {
        _currentParcel = _lstParcel[id];
        ParcelCanvas parcelInfo = _parcelInfo.GetComponentInChildren<ParcelCanvas>();
        parcelInfo.Title = _currentParcel.Type.ToString();
        _parcelInfo.gameObject.SetActive(true);
    }

    void UnSelectParcel()
    {
        _currentParcel = null;
        _parcelInfo.gameObject.SetActive(false);
    }
}
