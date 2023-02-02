using System.Collections.Generic;
using UnityEngine;

public class BuyWeaponButtonSettings : MonoBehaviour
{
    public static BuyWeaponButtonSettings Instance { get; private set; }

    [SerializeField] private BuyWeaponButton _mainBuyWeaponButton;

    private readonly Dictionary<int, uint> _weaponsCostDictionary = new();
    private readonly List<BuyWeaponButton> _buttonsList = new();

    private void Awake()
    {
        uint startWeaponCost = 50;
        for (int i = 0; i < 17; i++)
        {
            _weaponsCostDictionary.Add(i, (uint)(startWeaponCost * (i + 1)));
            startWeaponCost += startWeaponCost;
        }

        Instance = this;
    }

    public void AddButtonToList(BuyWeaponButton button)
    {
        if (!_buttonsList.Contains(button))
            _buttonsList.Add(button);
    }

    public void SetValueCost(int key, uint value)
    {
        _weaponsCostDictionary[key] = value;

        foreach (var button in _buttonsList)
            if (button.CurrentWeaponLevel == key)
                button.FormatCostText();
    }

    public uint GetValueCost(int key) => _weaponsCostDictionary[key];

    public void CheckWeaponLevel(int weaponLevel)
    {
        if (_mainBuyWeaponButton.CurrentWeaponLevel < weaponLevel)
            _mainBuyWeaponButton.SetButtonSettings(weaponLevel);
    }
}