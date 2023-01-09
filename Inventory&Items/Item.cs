using UnityEngine;

public class Item
{
    public ItemEnum ItemType { get; private set; }
    public Gun InventoryGun { get; private set; }

    public bool IsInInventory;

    public void SetGunInventory(Gun gun)
    {
        InventoryGun = gun;
    }

    public enum ItemEnum
    {
        Pistol,
        Nova,
        Shotgun,
        Uzi,
        Ump,
        Ak47,
        M4a4
    }

    public Item(ItemEnum item)
    {
        ItemType = item;
    }

    public Sprite GetSprite()
    {
        switch (ItemType)
        {
            default:
            case ItemEnum.Pistol: return ItemAssets.Singleton.Pistol;
            case ItemEnum.Nova: return ItemAssets.Singleton.Nova;
            case ItemEnum.Shotgun: return ItemAssets.Singleton.Shotgun;
            case ItemEnum.Uzi: return ItemAssets.Singleton.Uzi;
            case ItemEnum.Ump: return ItemAssets.Singleton.Ump;
            case ItemEnum.Ak47: return ItemAssets.Singleton.Ak47;
            case ItemEnum.M4a4: return ItemAssets.Singleton.M4a4;
        }
    }
}