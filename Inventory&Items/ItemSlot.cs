using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool IsSlotEmpty => _isSlotEmpty;

    private RectTransform _slotTransform;
    private Gun _gun;
    private bool _isSlotEmpty = true;

    public Gun GetGun() => _gun;

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

    private void Awake()
    {
        _slotTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_gun != null)
        {
            _gun.UpgradeGun();
            _gun.SetGun(new Item(_gun.GunItem), this);

            eventData.pointerDrag.GetComponent<Gun>().DestroyGun();
            // eventData.pointerDrag.gameObject.SetActive(false);
            if (_gun != null)
                Player.Singleton.UpgradeWeapon(_gun.GunItem);
            return;
        }

        if (eventData.pointerDrag != null)
        {
            var objectRTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            _gun = objectRTransform.GetComponent<Gun>();
            objectRTransform.anchorMax = _slotTransform.anchorMax;
            objectRTransform.anchorMin = _slotTransform.anchorMin;
            objectRTransform.anchoredPosition = new Vector2(0, 0);
            _gun.SetSlot(this);
        }
    }
}