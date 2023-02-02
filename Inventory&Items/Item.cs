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
        Glock,
        Usp,
        Nova,
        Pumpgun,
        Spas12,
        Scorp,
        Mac10,
        Mp5,
        P90,
        Vector,
        Ak47,
        M16a4,
        Aug,
        Hk416,
        Scar,
        Tar21,
        M249
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
            case ItemEnum.Glock: return ItemAssets.Instance.Glock;
            case ItemEnum.Usp: return ItemAssets.Instance.Usp;
            case ItemEnum.Nova: return ItemAssets.Instance.Nova;
            case ItemEnum.Pumpgun: return ItemAssets.Instance.Pumpgun;
            case ItemEnum.Spas12: return ItemAssets.Instance.Spas12;
            case ItemEnum.Scorp: return ItemAssets.Instance.Scorp;
            case ItemEnum.Mac10: return ItemAssets.Instance.Mac10;
            case ItemEnum.Mp5: return ItemAssets.Instance.Mp5;
            case ItemEnum.P90: return ItemAssets.Instance.P90;
            case ItemEnum.Vector: return ItemAssets.Instance.Vector;
            case ItemEnum.Ak47: return ItemAssets.Instance.Ak47;
            case ItemEnum.M16a4: return ItemAssets.Instance.M16a4;
            case ItemEnum.Aug: return ItemAssets.Instance.Aug;
            case ItemEnum.Hk416: return ItemAssets.Instance.Hk416;
            case ItemEnum.Scar: return ItemAssets.Instance.Scar;
            case ItemEnum.Tar21: return ItemAssets.Instance.Tar21;
            case ItemEnum.M249: return ItemAssets.Instance.M249;
        }
    }
}