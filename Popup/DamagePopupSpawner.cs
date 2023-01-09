using UnityEngine;

public class DamagePopupSpawner : MonoBehaviour
{
    public static DamagePopupSpawner Singleton { get; private set; }

    [SerializeField] private GameObject _damagePopup, _healPopup;

    private PopupPooler _pooler;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _pooler = new PopupPooler(_damagePopup, 25, transform);
    }

    public void CreateDamagePopupFromPool(Vector3 position, int damage, bool isHeal = false)
    {
        if (!isHeal)
        {
            var popup = _pooler.GetFreePopup();
            popup.Setup(damage, position);
        }
        else
        {
            var popup = Instantiate(_healPopup).GetComponent<DamagePopup>();
            popup.Setup(damage, position);
        }
    }
}