using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Item.ItemEnum GunItem { get; private set; }
    public int GunLevel { get; private set; }

    [SerializeField] private TextMeshProUGUI _gunLevelText;

    private Image _gunImage;
    private ItemSlot _slot;


    private void Awake()
    {
       // _gunLevelText = GetComponentInChildren<TextMeshProUGUI>();
        _gunLevelText.SetText((GunLevel + 1).ToString());
        if (_gunImage == null)
            _gunImage = GetComponent<Image>();
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
        DragDropItemList.Instance.ActiveAllRaycast();
        DragDropItemList.Instance.RemoveItemFromList(GetComponent<CanvasGroup>());
        _slot.SetFreeSlot();
        UI_Inventory.Instance.RemoveGunFromInventory(this);
        Destroy(gameObject);
    }
}