using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> _itemList;

    public List<Item> GetItemList() => _itemList;

    public Inventory()
    {
        _itemList = new List<Item>();
        AddItem(new Item(Item.ItemEnum.Pistol));
    }

    public void AddItem(Item item)
    {
        _itemList.Add(item);
    }

    public void RemoveItem(Gun gun)
    {
        int itemForDestroy = 0;

        for (int i = 0; i < _itemList.Count; i++)
            if (_itemList[i].InventoryGun == gun)
                itemForDestroy = i;

        if (itemForDestroy > 0)
            _itemList.Remove(_itemList[itemForDestroy]);
    }
}