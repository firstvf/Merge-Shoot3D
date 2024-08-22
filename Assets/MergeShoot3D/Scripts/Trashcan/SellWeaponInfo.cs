using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellWeaponInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private Image _weaponImage;
    private Gun _gun;

    public void ShowSellInfo(Gun gun)
    {
        _gun = gun;
        var cost =(uint) (BuyWeaponButtonSettings.Instance.GetValueCost(_gun.GunLevel)/1.5f);
        _costText.SetText(cost.ToString());
        _weaponImage.sprite = _gun.GunImage.sprite;
        gameObject.SetActive(true);
    }

    public void SellWeapon()
    {
        MoneyBank.Instance.AddMoney((uint)(BuyWeaponButtonSettings.Instance.GetValueCost(_gun.GunLevel) / 1.5f));
        _gun.DestroyGun();
        gameObject.SetActive(false);
    }
}