using System.Collections.Generic;

[System.Serializable]
public class InventoryData
{
    private List<(int, int)> _inventory;
     /// <summary>
     /// Inventory: (Gun level , Slot number)
     /// </summary>
     /// <returns></returns>
    public List<(int,int)> GetInventory() => _inventory;

    public InventoryData(Inventory inventory)
    {
        _inventory = new List<(int, int)>();

        foreach (var gun in inventory.GetItemList())
        {
            _inventory.Add((gun.InventoryGun.GunLevel, gun.InventoryGun.GunSlot.GetSlotNumber()));
        }
    }
}