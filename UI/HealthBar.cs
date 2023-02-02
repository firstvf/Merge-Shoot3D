using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar, _parentPrefab;
    [SerializeField] private Image _healthBarImage;

    private DamagePopupSpawner _popup;
    private bool _isAbleToMove;
    private Vector3 _startPosition;
    private float _maxHealth;

    private void Awake()
    {
        _startPosition = transform.position;
        if (_healthBar.activeInHierarchy)
            _isAbleToMove = true;
        _popup = DamagePopupSpawner.Instance;
    }

    private void OnEnable()
    {
        _healthBarImage.fillAmount = _maxHealth;
    }

    private void Update()
    {
        MoveHealthBar();
    }

    private void MoveHealthBar()
    {
        if (_isAbleToMove)
            transform.position = new Vector3(_parentPrefab.transform.position.x, _startPosition.y, _parentPrefab.transform.position.z);
    }

    public void HealthBarSettings(int maxHealth)
    {
        _maxHealth = maxHealth;
        _healthBarImage.fillAmount = _maxHealth;
    }

    public void UpdateHealthBar(int currentHealth, int damage, bool isHeal = false)
    {
        if (_popup == null)
            _popup = DamagePopupSpawner.Instance;
        if (isHeal)
            _popup.CreateDamagePopupFromPool(new Vector3
                (_parentPrefab.transform.position.x, _startPosition.y + 0.5f, _parentPrefab.transform.position.z), 100, true);
        else
            _popup.CreateDamagePopupFromPool(new Vector3
               (_parentPrefab.transform.position.x, _startPosition.y + 0.5f, _parentPrefab.transform.position.z), damage);


        if (!_healthBar.activeInHierarchy)
        {
            _isAbleToMove = true;
            _healthBar.SetActive(true);
        }
        _healthBarImage.fillAmount = (float)currentHealth / _maxHealth;
        if (currentHealth <= 0)
        {
            _isAbleToMove = false;
            _healthBar.SetActive(false);
        }
    }
}