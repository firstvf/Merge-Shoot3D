using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public static UI_Inventory Singleton { get; private set; }

    [SerializeField] private ItemSlot[] _itemSlot;
    [SerializeField] private Transform _item;

    private Inventory _inventory;
    private Transform _container;

    private void Awake()
    {
        Singleton = this;
        _container = transform;
    }

    public void SetInventory(Inventory inventory)
    {
        this._inventory = inventory;
        RefreshInventoryItems();
    }

    public void RemoveGunFromInventory(Gun gun)
    {
        _inventory.RemoveItem(gun);
    }

    public void RefreshInventoryItems()
    {
        int itemSlot = 0;
        bool isItemHoldSlot = false;
        foreach (var item in _inventory.GetItemList())
        {
            if (!item.IsInInventory && itemSlot < _itemSlot.Length)
            {
                item.IsInInventory = true;

                if (_container == null)
                    _container = transform;
                RectTransform gunRTransform = Instantiate(_item, _container).GetComponent<RectTransform>();
                gunRTransform.name = $"Gun: {itemSlot}";
                item.SetGunInventory(gunRTransform.GetComponent<Gun>());


                foreach (var slot in _itemSlot)
                    if (!isItemHoldSlot && slot.IsSlotEmpty)
                    {
                        isItemHoldSlot = true;
                        gunRTransform.anchorMax = slot.GetComponent<RectTransform>().anchorMax;
                        gunRTransform.anchorMin = slot.GetComponent<RectTransform>().anchorMin;
                        gunRTransform.GetComponent<Gun>().SetGun(new Item(0), slot);
                        continue;
                    }

                gunRTransform.anchoredPosition = new Vector2(0, 0);
                gunRTransform.gameObject.SetActive(true);

                gunRTransform.GetComponent<Image>().sprite = item.GetSprite();
            }
            itemSlot++;
        }
    }

    public bool IsAnyEmptySlot()
    {
        if (_inventory.GetItemList().Count < _itemSlot.Length)
            return true;
        else return false;
    }
}