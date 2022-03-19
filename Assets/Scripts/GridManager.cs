using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid info")]
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [Header("Canvas")]
    [SerializeField] private GameObject _parcelInfoNone;
    [SerializeField] private GameObject _parcelInfoCulture;

    [Header("Prefabs")]
    [SerializeField] private GameObject _hoverPrefabs;

    private List<Parcel> _lstParcel;
    private Parcel _currentParcel;

    private GameObject _hover;

    private bool _isParcelSelected { get { return _currentParcel != null; } }

    void Start()
    {
        CreateGrid();

        _parcelInfoNone.gameObject.SetActive(false);
        _hover = Instantiate(_hoverPrefabs);
        _parcelInfoCulture.gameObject.SetActive(false);
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
        OnHover();
    }

    void OnHover()
    {
        if (_isParcelSelected) { return; }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < 0 || mousePosition.y < 0 || mousePosition.x >= _width || mousePosition.y >= _height) {
            _hover.transform.position = new Vector3(50f, 50f);
            return; 
        }

        Vector2 position = new Vector2(Mathf.FloorToInt(mousePosition.x) + 0.5f, Mathf.FloorToInt(mousePosition.y)+0.5f);
        _hover.transform.position = position;
    }

    void OnClick()
    {
        if (_isParcelSelected) { return; }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < 0 || mousePosition.y < 0 || mousePosition.x >= _width || mousePosition.y >= _height) { return; }

        int id = GameManager.Instance.CoordToId(mousePosition, _width);
        SelectParcel(id, new Vector2(Mathf.FloorToInt(mousePosition.x)+0.5f, Mathf.FloorToInt(mousePosition.y)+1.25f));
    }

    void SelectParcel(int id, Vector2 position)
    {
        _currentParcel = _lstParcel[id];
        GameObject parcel = _parcelInfoNone;

        if (_currentParcel.Type == Parcel.Types.Culture)
        {
            parcel = _parcelInfoCulture;
            ParcelCanvas parcelInfo = parcel.GetComponentInChildren<ParcelCanvas>();
            parcelInfo.Title = _currentParcel.Name;
        } else
        {
            ParcelCanvas parcelInfo = parcel.GetComponentInChildren<ParcelCanvas>();
            parcelInfo.Title = _currentParcel.Type.ToString();
        }
        parcel.transform.position = Camera.main.WorldToScreenPoint(position);
        parcel.gameObject.SetActive(true);
    }

    public void UnSelectParcel()
    {
        _currentParcel = null;
        _parcelInfoNone.gameObject.SetActive(false);
        _parcelInfoCulture.gameObject.SetActive(false);
    }
}
