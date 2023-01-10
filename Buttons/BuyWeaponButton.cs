using TMPro;
using UnityEngine;

public class BuyWeaponButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Shop _shop;
    [SerializeField] private UI_Inventory _uiInventory;

    private int _weaponCost;
    private MoneyBank _bank;

    private void Start()
    {
        _weaponCost = 5;
        _priceText.SetText(_weaponCost.ToString());
    }

    public void BuyWeapon()
    {
        if (_bank == null)
            _bank = MoneyBank.Singleton;

        if (_bank.Money > _weaponCost&&_uiInventory.IsAnyEmptySlot())
        {
            _bank.WithdrawMoney(_weaponCost);
            _weaponCost = (int)(_weaponCost * 1.2f);
            _priceText.SetText(_weaponCost.ToString());
            _shop.CreateItemOnInventory();
        }
    }
}