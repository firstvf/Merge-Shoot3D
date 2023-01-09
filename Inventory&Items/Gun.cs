using System;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private ItemSlot _slot;

    private Image _gunImage;
    public Item.ItemEnum GunItem { get; private set; }

    public int GunLevel { get; private set; }

    private void Awake()
    {
        if (_gunImage == null)
            _gunImage = GetComponent<Image>();
    }

    public void UpgradeGun()
    {
        if (GunLevel < Convert.ToInt32(Item.ItemEnum.M4a4))
            GunLevel++;
        GunItem = (Item.ItemEnum)GunLevel;
    }

    public void SetGun(Item item, ItemSlot slot)
    {
        GunItem = item.ItemType;

        if (_gunImage == null)
            _gunImage = GetComponent<Image>();

        _gunImage.sprite = item.GetSprite();
        SetSlot(slot);
    }

    public void SetSlot(ItemSlot slot)
    {
        if (_slot != null)
            _slot.SetFreeSlot();
        _slot = slot;
        _slot.SetGunInSlot(this);
    }

    public void DestroyGun()
    {
        _slot.SetFreeSlot();
        UI_Inventory.Singleton.RemoveGunFromInventory(this);
        Destroy(gameObject);
    }
}