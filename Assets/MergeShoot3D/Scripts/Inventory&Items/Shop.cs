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

    private void Start()
    {
        if (SaveSystem.LoadGame() == null)
            CreateItemOnInventory();
        else
        {
            var inventory = SaveSystem.LoadGame().GetInventory();

            foreach (var item in inventory)
                CreateItemOnInventory(item.Item1, true, item.Item2);
        }
    }

    public void CreateItemOnInventory(int itemLevel = 0, bool isGameLoaded = false, int loadedHoldSlot = 0)
    {
        _inventory.AddItem(new Item((Item.ItemEnum)itemLevel));
        _uiInventory.AddItemInUiInventory(itemLevel, isGameLoaded, loadedHoldSlot);
    }

    public void UpgradeWeapon()
    {
        _audioSource.PlayOneShot(_upgradeSound);
    }
}