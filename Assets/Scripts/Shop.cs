using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _ShopItemPrefab;
    [SerializeField] private RectTransform _cultureTransform;
    [SerializeField] private RectTransform _actionneurTransform;
    [SerializeField] private RectTransform _capteurTransform;

    [SerializeField] List<Culture> _itemsCulture;
    [SerializeField] List<Actuator> _itemsActionneur;
    [SerializeField] List<Sensor> _itemsCapteur;

    void Start()
    {
        int offset = 250;
        int offsetY = -100;
        for (int i = 0; i < _itemsCulture.Count; i++)
        {
            GameObject item = Instantiate(_ShopItemPrefab, _cultureTransform);
            item.GetComponent<ShopItem>().Init(_itemsCulture[i]);
            item.transform.position = new Vector3(_cultureTransform.position.x + (i + 1) * offset, _cultureTransform.position.y);
        }
        for (int i = 0; i < _itemsActionneur.Count; i++)
        {
            GameObject item = Instantiate(_ShopItemPrefab, _actionneurTransform);
            item.GetComponent<ShopItem>().Init(_itemsActionneur[i]);
            item.transform.position = new Vector3(_actionneurTransform.position.x + (i + 1) * offset, _actionneurTransform.position.y);
        }
        for (int i = 0; i < _itemsCapteur.Count; i++)
        {
            GameObject item = Instantiate(_ShopItemPrefab, _capteurTransform);
            item.GetComponent<ShopItem>().Init(_itemsCapteur[i]);
            item.transform.position = new Vector3(_capteurTransform.position.x + (i + 1) * offset, _capteurTransform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
