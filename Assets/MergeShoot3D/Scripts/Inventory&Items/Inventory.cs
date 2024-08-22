using System.Collections.Generic;

public class Inventory
{
    private readonly List<Item> _itemList;

    public List<Item> GetItemList() => _itemList;

    public Inventory()
    {
        _itemList = new List<Item>();   
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

        _itemList.Remove(_itemList[itemForDestroy]);
    }
}