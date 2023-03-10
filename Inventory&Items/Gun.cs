using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Item.ItemEnum GunItem { get; private set; }
    public int GunLevel { get; private set; }
    public ItemSlot GunSlot { get; private set; }
    public Image GunImage { get; private set; }

    [SerializeField] private TextMeshProUGUI _gunLevelText;

    private void Awake()
    {
        _gunLevelText.SetText((GunLevel + 1).ToString());
        if (GunImage == null)
            GunImage = GetComponent<Image>();
    }

    public void UpgradeGun()
    {
        if (GunLevel < Convert.ToInt32(Item.ItemEnum.M249))
            GunLevel++;
        GunItem = (Item.ItemEnum)GunLevel;
        _gunLevelText.SetText((GunLevel + 1).ToString());
    }

    public void SetGun(Item item, ItemSlot slot)
    {
        GunItem = item.ItemType;
        GunLevel = (int)item.ItemType;
        if (GunImage == null)
            GunImage = GetComponent<Image>();

        GunImage.sprite = item.GetSprite();
        SetSlot(slot);
    }

    public void SetSlot(ItemSlot slot)
    {
        if (GunSlot != null)
            GunSlot.SetFreeSlot();
        GunSlot = slot;
        GunSlot.SetGunInSlot(this);
    }

    public void DestroyGun()
    {
        DragDropItemList.Instance.ActiveAllRaycast();
        DragDropItemList.Instance.RemoveItemFromList(GetComponent<CanvasGroup>());
        GunSlot.SetFreeSlot();
        UI_Inventory.Instance.RemoveGunFromInventory(this);
        Destroy(gameObject);
    }
}