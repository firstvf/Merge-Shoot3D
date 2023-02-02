using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyWeaponButton : MonoBehaviour
{
    public int CurrentWeaponLevel { get; private set; }

    [SerializeField] private TextMeshProUGUI _priceText, _weaponLevelText;
    [SerializeField] private Image _weaponImage;

    private BuyWeaponButtonSettings _buttonSettings;
    private ItemAssets _itemAssetsSprites;
    private Shop _shop;
    private UI_Inventory _uiInventory;
    private MoneyBank _bank;

    private void Start()
    {
        _buttonSettings = BuyWeaponButtonSettings.Instance;
        _buttonSettings.AddButtonToList(this);
        FormatCostText();
    }
    public void FormatCostText() =>
        _priceText.SetText(FormatText.FormatTextMoney(_buttonSettings.GetValueCost(CurrentWeaponLevel)));

    public void SetButtonSettings(int weaponLevel)
    {
        CurrentWeaponLevel = weaponLevel;
        ChangeButtonWeaponImage();
        _weaponLevelText.SetText((CurrentWeaponLevel + 1).ToString());
        if (_buttonSettings == null)
            _buttonSettings = BuyWeaponButtonSettings.Instance;  
    }

    public void BuyWeapon()
    {
        if (_bank == null || _uiInventory == null || _shop == null)
        {
            _bank = MoneyBank.Instance;
            _uiInventory = UI_Inventory.Instance;
            _shop = Shop.Instance;
        }

        if (_bank.Money > _buttonSettings.GetValueCost(CurrentWeaponLevel) && _uiInventory.IsAnyEmptySlot())
        {
            _buttonSettings.CheckWeaponLevel(CurrentWeaponLevel);
            _bank.WithdrawMoney(_buttonSettings.GetValueCost(CurrentWeaponLevel));

            _buttonSettings.SetValueCost(CurrentWeaponLevel, (uint)
                (_buttonSettings.GetValueCost(CurrentWeaponLevel) * 1.2f));

            FormatCostText();
            _shop.CreateItemOnInventory(CurrentWeaponLevel);
        }
    }

    private void ChangeButtonWeaponImage()
    {
        if (_itemAssetsSprites == null)
            _itemAssetsSprites = ItemAssets.Instance;

        _weaponImage.sprite = _itemAssetsSprites.GetWeaponSpriteWithValue(CurrentWeaponLevel);
    }    
}