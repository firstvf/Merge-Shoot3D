using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool IsSlotEmpty => _isSlotEmpty;

    private RectTransform _slotTransform;
    private Gun _gun;
    private bool _isSlotEmpty = true;

    public Gun GetGun() => _gun;
    private void Awake()
    {
        _slotTransform = GetComponent<RectTransform>();
    }

    public void SetGunInSlot(Gun gun)
    {
        if (_isSlotEmpty)
        {
            _gun = gun;
            _isSlotEmpty = false;
        }
    }

    public void SetFreeSlot()
    {
        _isSlotEmpty = true;
        _gun = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_gun != null)
            CheckSameWeapons(eventData);
        else
        {
            if (eventData.pointerDrag != null)
            {
                var objectRTransform = eventData.pointerDrag.GetComponent<RectTransform>();
                _gun = objectRTransform.GetComponent<Gun>();
                objectRTransform.anchorMax = _slotTransform.anchorMax;
                objectRTransform.anchorMin = _slotTransform.anchorMin;
                objectRTransform.anchoredPosition = new Vector2(0, 0);
                _gun.SetSlot(this);
            }
            DragDropItemList.Singleton.ActiveAllRaycast();
        }
    }

    public void CheckSameWeapons(PointerEventData dragGun)
    {
        if (_gun != null && dragGun.pointerDrag.GetComponent<Gun>().GunLevel == _gun.GunLevel &&
             dragGun.pointerDrag.GetComponent<Gun>() != this._gun)
        {
            _gun.UpgradeGun();
            _gun.SetGun(new Item(_gun.GunItem), this);
            Shop.Singleton.UpgradeWeapon();
            Player.Singleton.UpgradeWeapon(_gun.GunItem);
            dragGun.pointerDrag.GetComponent<Gun>().DestroyGun();
        }
        else if (_gun != null && dragGun.pointerDrag.GetComponent<Gun>().GunLevel != _gun.GunLevel)
            dragGun.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}