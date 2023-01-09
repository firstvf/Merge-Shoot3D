using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Singleton { get; private set; }
    public int CurrentHealth { get; private set; }

    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private HealthBar _hpBar;
    [SerializeField] private float _attackRange;

    private PlayerAnimationController _animationController;
    private WaitForSeconds _defaultAttackSpeed;
    private WaitForSeconds _reloading;
    private AudioSource _audioSource;
    private List<Enemy> _targetList;
    private Enemy _target;
    private Quaternion _baseRotation;
    private int _currentWeaponLevel;
    private int _maxHealth;
    private int _damage;
    private bool _isRifleState = false;
    private bool _isAbleToShoot;
    private bool _isTargetSet;

    public void UpgradeWeapon(Item.ItemEnum weapon)
    {
        int upgradeLevel = (int)weapon;
        for (int i = 0; i < upgradeLevel; i++)
            if (_currentWeaponLevel < upgradeLevel)
            {
                _damage += 10;
                _currentWeaponLevel++;
            }
        foreach (var item in _weapons)
        {
            item.SetActive(false);
        }
        _weapons[_currentWeaponLevel].SetActive(true);
        if (!_isRifleState)
        {
            _isRifleState = true;
            _animationController.ChangeRifleLayer();
        }
    }

    private void Awake()
    {
        _animationController = GetComponent<PlayerAnimationController>();
        _audioSource = GetComponent<AudioSource>();
        Singleton = this;
        _baseRotation = transform.rotation;
    }

    private void Start()
    {
        _isAbleToShoot = true;
        _targetList = EnemyTargetList.Singleton.GetList();
        _maxHealth = 100;
        CurrentHealth = _maxHealth;
        _damage = 20;
        _reloading = new WaitForSeconds(0.2f);
        _defaultAttackSpeed = new WaitForSeconds(1f);
        _hpBar.HealthBarSettings(_maxHealth);
    }

    private void Update()
    {
        if (!_isTargetSet)
            LookingForTarget();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    public void Heal()
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth = _maxHealth;
            _hpBar.UpdateHealthBar(_maxHealth, 100, true);
        }
    }

    public void Gethit(int damage)
    {
        var randomDamage = Random.Range(damage - 5, damage);
        if (CurrentHealth > 0)
        {
            CurrentHealth -= randomDamage;
            _hpBar.UpdateHealthBar(CurrentHealth, randomDamage);
            if (CurrentHealth <= 0)
                Die();
        }
    }

    private void Die()
    {
        _animationController.SetDieTrigger();
        StartCoroutine(DeathTimer());
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void LookingForTarget()
    {
        foreach (var enemy in _targetList)
            if (Vector3.Distance(transform.position, enemy.transform.position) < _attackRange && !_isTargetSet)
            {
                _isTargetSet = true;
                _target = enemy;
                StartCoroutine(AttackCoroutine());
            }
    }

    public void Attack()
    {
        if (_isTargetSet && _isAbleToShoot && _target.CurrentHealth > 0 && CurrentHealth > 0)
        {
            StartCoroutine(Reloading());
            _target.GetHit(_damage);
            _audioSource.PlayOneShot(_shootSound);
            transform.LookAt(_target.transform.position);
        }
    }

    private IEnumerator Reloading()
    {
        _isAbleToShoot = false;
        yield return _reloading;
        _isAbleToShoot = true;
    }

    private IEnumerator AttackCoroutine()
    {
        while (_target.CurrentHealth > 0 && _isAbleToShoot)
        {
            Attack();
            yield return _defaultAttackSpeed;
        }
        _isTargetSet = false;
        transform.rotation = _baseRotation;
    }
}