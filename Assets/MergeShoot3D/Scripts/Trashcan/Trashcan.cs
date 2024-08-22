using UnityEngine;
using UnityEngine.EventSystems;

public class Trashcan : MonoBehaviour, IDropHandler
{
    [SerializeField] private SellWeaponInfo _sellWeaponInfo;

    public void OnDrop(PointerEventData eventData)
    {
        var gun = eventData.pointerDrag.GetComponent<Gun>();
        if (gun.GunLevel != Player.Instance.CurrentWeaponLevel)
            _sellWeaponInfo.ShowSellInfo(gun);
    }
}