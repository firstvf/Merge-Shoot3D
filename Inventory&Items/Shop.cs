using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Singleton { get; private set; }

    [SerializeField] private AudioClip _upgradeSound;
    [SerializeField] UI_Inventory _uiInventory;

    private AudioSource _audioSource;
    private Inventory _inventory;

    private void Awake()
    {
        Singleton = this;
        _audioSource = GetComponent<AudioSource>();
        _inventory = new Inventory();
        _uiInventory.SetInventory(_inventory);
    }

    public void CreateItemOnInventory()
    {
        _inventory.AddItem(new Item(Item.ItemEnum.Pistol));
        _uiInventory.RefreshInventoryItems();
    }

    public void UpgradeWeapon()
    {
        _audioSource.PlayOneShot(_upgradeSound);
    }
}