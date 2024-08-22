using UnityEngine;

public class DamagePopupSpawner : MonoBehaviour
{
    public static DamagePopupSpawner Instance { get; private set; }

    [SerializeField] private DamagePopup _damagePopup;
    [SerializeField] private GameObject _healPopup;

    private MonobehObjectPooler<DamagePopup> _pooler;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _pooler = new MonobehObjectPooler<DamagePopup>(_damagePopup, transform, 15);
    }

    public void CreateDamagePopupFromPool(Vector3 position, int damage, bool isHeal = false)
    {
        if (!isHeal)
        {
            var popup = _pooler.GetFreeMonobehObject();
            popup.Setup(damage, position);
        }
        else
        {
            var popup = Instantiate(_healPopup).GetComponent<DamagePopup>();
            popup.Setup(damage, position);
        }
    }
}