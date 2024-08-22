using System.Collections.Generic;
using UnityEngine;

public class BuyWeaponButtonSettings : MonoBehaviour
{
    public static BuyWeaponButtonSettings Instance { get; private set; }

    [SerializeField] private BuyWeaponButton _mainBuyWeaponButton;

    private  Dictionary<int, uint> _weaponsCostDictionary;
    private readonly List<BuyWeaponButton> _buttonsList = new();

    public Dictionary<int, uint> GetWeaponsCostDictionary() => _weaponsCostDictionary;
    public int GetMainWeaponButtonLevel() => _mainBuyWeaponButton.CurrentWeaponLevel;

    private void Awake()
    {
        if(SaveSystem.LoadGame() == null)
        {
            uint startWeaponCost = 50;
            _weaponsCostDictionary = new();
            for (int i = 0; i < 17; i++)
            {
                _weaponsCostDictionary.Add(i, (uint)(startWeaponCost * (i + 1)));
                startWeaponCost += startWeaponCost;
            }
        }
        else
        {
            _weaponsCostDictionary = new();
            var load = SaveSystem.LoadGame();
            _weaponsCostDictionary = load.GetWeaponsCost();
            _mainBuyWeaponButton.SetButtonSettings(load.GetWeaponButtonLevel());
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