using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public string name = "Test";
    public int price = 10;

    public Inventory.ItemType Type;

    public Item(string name, int price, Inventory.ItemType type)
    {
        this.name = name;
        this.price = price;
        this.Type = type;
    }
}

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _ShopItemPrefab;
    [SerializeField] private RectTransform _cultureTransform;
    [SerializeField] private RectTransform _actionneurTransform;
    [SerializeField] private RectTransform _capteurTransform;

    private List<Item> _itemsCulture;
    private List<Item> _itemsActionneur;
    private List<Item> _itemsCapteur;

    private void Awake()
    {
        _itemsCulture = new List<Item>();
        _itemsCulture.Add(new Item("Wheat", 5, Inventory.ItemType.Wheat));

        _itemsActionneur = new List<Item>();
        _itemsActionneur.Add(new Item("Alerte", 35, Inventory.ItemType.Alarm));
        _itemsActionneur.Add(new Item("Arroseur", 60, Inventory.ItemType.Sprinkler));

        _itemsCapteur = new List<Item>();
        _itemsCapteur.Add(new Item("Humidité", 10, Inventory.ItemType.HumiditySensor));
    }

    void Start()
    {
        int offset = 200;
        int offsetY = -100;
        for (int i = 0; i < _itemsCulture.Count; i++)
        {
            GameObject item = Instantiate(_ShopItemPrefab, _cultureTransform);
            item.GetComponent<ShopItem>().UpdateText(_itemsCulture[i].name, _itemsCulture[i].price, _itemsCulture[i].Type);
            item.transform.position = new Vector3(_cultureTransform.position.x + i * offset, _cultureTransform.position.y + offsetY);
        }
        for (int i = 0; i < _itemsActionneur.Count; i++)
        {
            GameObject item = Instantiate(_ShopItemPrefab, _actionneurTransform);
            item.GetComponent<ShopItem>().UpdateText(_itemsActionneur[i].name, _itemsActionneur[i].price, _itemsActionneur[i].Type);
            item.transform.position = new Vector3(_actionneurTransform.position.x + i * offset, _actionneurTransform.position.y + offsetY);
        }
        for (int i = 0; i < _itemsCapteur.Count; i++)
        {
            GameObject item = Instantiate(_ShopItemPrefab, _capteurTransform);
            item.GetComponent<ShopItem>().UpdateText(_itemsCapteur[i].name, _itemsCapteur[i].price, _itemsCapteur[i].Type);
            item.transform.position = new Vector3(_capteurTransform.position.x + i * offset, _capteurTransform.position.y + offsetY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
