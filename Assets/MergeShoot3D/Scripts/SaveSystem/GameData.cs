using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    private List<(int, int)> _inventory;
    private Dictionary<int, uint> _weaponsCost;
    private int _playerWeaponLevel;
    private int _weaponButtonLevel;
    private uint _money;

    public uint GetMoney() => _money;
    public Dictionary<int, uint> GetWeaponsCost() => _weaponsCost;
    public int GetWeaponButtonLevel() => _weaponButtonLevel;
    public List<(int,int)> GetInventory() => _inventory;
    public int GetPlayerWeaponLevel() => _playerWeaponLevel;

    public GameData()
    {
        _money = MoneyBank.Instance.Money;
        _playerWeaponLevel = Player.Instance.CurrentWeaponLevel;
        _weaponsCost = BuyWeaponButtonSettings.Instance.GetWeaponsCostDictionary();
        _weaponButtonLevel = BuyWeaponButtonSettings.Instance.GetMainWeaponButtonLevel();

        _inventory = new List<(int, int)>();
        foreach (var gun in UI_Inventory.Instance.GetInventory().GetItemList())        
            _inventory.Add((gun.InventoryGun.GunLevel, gun.InventoryGun.GunSlot.GetSlotNumber()));        
    }
}