using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("test");
        //if (_parcelInfo.gameObject.activeSelf) { return; }
        //Vector2 mousePosition = Input.mousePosition;

        //if (mousePosition.x < 0 || mousePosition.y < 0 || mousePosition.x >= _width || mousePosition.y >= _height) { return; }

        //int id = Mathf.FloorToInt(mousePosition.y) * _width + Mathf.FloorToInt(mousePosition.x);
        //SelectParcel(id);
    }

    void SelectParcel(int id)
    {
        _currentParcel = _lstParcel[id];

        _parcelInfo.gameObject.SetActive(true);
    }
}
