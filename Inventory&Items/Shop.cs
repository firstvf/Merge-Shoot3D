using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; private set; }

    [SerializeField] private AudioClip _upgradeSound;
    [SerializeField] UI_Inventory _uiInventory;

    private AudioSource _audioSource;
    private Inventory _inventory;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _inventory = new Inventory();
        _uiInventory.SetInventory(_inventory);
    }

    public void CreateItemOnInventory(int itemLevel = 0)
    {
        _inventory.AddItem(new Item((Item.ItemEnum)itemLevel));
        _uiInventory.RefreshInventoryItems(itemLevel);
    }

    public void UpgradeWeapon()
    {
        _audioSource.PlayOneShot(_upgradeSound);
    }
}