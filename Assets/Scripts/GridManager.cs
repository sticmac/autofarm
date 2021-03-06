using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{
    [Header("Grid info")]
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _HumidityLosePerSeconds;

    [Header("Sensor")]
    [SerializeField] private HumiditySensorView _sensorView;

    [Header("Canvas")]
    [SerializeField] private GameObject _parcelInfoNone;
    [SerializeField] private GameObject _parcelInfoCulture;
    [SerializeField] private GameObject _parcelInfoActuator;

    [Header("Prefabs")]
    [SerializeField] private GameObject _hoverPrefabs;

    private bool _parcelClickEnabled = true;

    private List<Parcel> _lstParcel;
    private Parcel _currentParcel;
    private RaycastHit2D hitMouse;

    private GameObject _hover;

    private bool _isParcelSelected { get { return _currentParcel != null; } }

    public Parcel CurrentParcel => _currentParcel;
    public RaycastHit2D HitMouse => hitMouse;

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
                GameObject parcel = new GameObject($"Cell [{x}/{y}]");
                Parcel p = parcel.AddComponent<Parcel>();
                p.HumidityLosePerSeconds = _HumidityLosePerSeconds;
                _lstParcel.Add(p);

                parcel.transform.position = new Vector3(x + 0.5f, y + 0.5f);
                parcel.transform.SetParent(transform, false);
            }
        }
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        hitMouse = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (hitMouse.collider == null) { _hover.transform.position = new Vector3(50f, 50f); return; }


        if (_parcelClickEnabled) {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
            OnHover();
        }

        if (_currentParcel)
        {
            _currentParcel.UpdateSensor(_sensorView);
        }
    }

    void OnHover()
    {
        if (_isParcelSelected) { return; }
        Vector2 mousePosition = hitMouse.point;

        Vector2 position = new Vector2(Mathf.FloorToInt(mousePosition.x) + 0.5f, Mathf.FloorToInt(mousePosition.y)+0.5f);
        _hover.transform.position = position;
    }

    void OnClick()
    {
        if (_isParcelSelected) { return; }

        Vector2 mousePosition = hitMouse.point;

        int id = CoordToId(mousePosition);
        ShowParcelMenu(id, new Vector2(Mathf.FloorToInt(mousePosition.x)+0.5f, Mathf.FloorToInt(mousePosition.y)+1.25f));
    }

    void ShowParcelMenu(int id, Vector2 offset)
    {
        _currentParcel = _lstParcel[id];

        GameObject parcel = _parcelInfoNone;
        if (_currentParcel.Type == Parcel.Types.Culture)
        {
            parcel = _parcelInfoCulture;
        }
        else if (_currentParcel.Type == Parcel.Types.Actioneur)
        {
            parcel = _parcelInfoActuator;
        }

        ParcelCanvas parcelInfo = parcel.GetComponentInChildren<ParcelCanvas>();
        parcelInfo.Title = _currentParcel.GetName();

        parcel.transform.position = Camera.main.WorldToScreenPoint(offset);
        parcel.gameObject.SetActive(true);
    }

    public void SetParcelClickEnabled(bool active) {
        _parcelClickEnabled = active;
    }

    public void UnSelectParcel()
    {
        _currentParcel = null;
        _parcelInfoNone.gameObject.SetActive(false);
        _parcelInfoCulture.gameObject.SetActive(false);
        _parcelInfoActuator.gameObject.SetActive(false);
    }

    public int CoordToId(Vector2 position)
    {
        return Mathf.FloorToInt(position.y) * _width + Mathf.FloorToInt(position.x);
    }

    public Parcel ParcelAtCoord(Vector2 position) {
        return _lstParcel[CoordToId(position)];
    }

    public Parcel ParcelNextToId(int id, Vector2 diff) {
        int retId = id + Mathf.FloorToInt(diff.y) * _width + Mathf.FloorToInt(diff.x);

        if (Vector2.Distance(GetCoordinatesForId(id), GetCoordinatesForId(retId)) > diff.magnitude) {
            return null;
        } else {
            return _lstParcel[retId];
        }
    }

    private Vector2 GetCoordinatesForId(int id) {
        return new Vector2(id % _width, id / _width);
    }

    public Vector2 GetClosestParcelCoordinates(Vector2 worldPosition) {
        return new Vector2(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y));
    }
}
