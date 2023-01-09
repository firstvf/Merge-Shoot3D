using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] UI_Inventory _uiInventory;
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory();
        _uiInventory.SetInventory(_inventory);        
    }

    public void CreateItemOnInventory()
    {
        _inventory.AddItem(new Item(Item.ItemEnum.Pistol));
        _uiInventory.RefreshInventoryItems();
    }
}