using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public int CurrentWeaponLevel { get; private set; }
    public int CurrentHealth { get; private set; }
    public bool IsTargetSet { get; private set; }

    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private HealthBar _hpBar;
    [SerializeField] private float _attackRange;

    private VisualEffect _weaponVFX;
    private VisualEffectsController _vfxController;
    private PlayerAnimationController _animationController;
    private WaitForSeconds _defaultAttackSpeed;
    private WaitForSeconds _reloading;
    private AudioSource _audioSource;
    private List<Enemy> _targetList;
    private Enemy _target;
    private Quaternion _baseRotation;
    private int _shotsCountAtTime = 1;
    private int _maxHealth;
    private int _damage;
    private bool _isAbleToShoot;
    private bool _isReloadingCoroutineStarted;


    // TEST
    public int TestWeaponLevel;
    public bool IsTestUpgradeWeapon;

    private void Awake()
    {
        _animationController = GetComponent<PlayerAnimationController>();
        _audioSource = GetComponent<AudioSource>();
        Instance = this;
        _baseRotation = transform.rotation;
        _vfxController = _weapons[CurrentWeaponLevel].GetComponentInChildren<VisualEffectsController>();
    }

    private void Start()
    {
        _isAbleToShoot = true;
        _targetList = EnemyTargetList.Instance.GetList();
        _maxHealth = 100;
        CurrentHealth = _maxHealth;
        CurrentWeaponSettings(_weapons[CurrentWeaponLevel].GetComponent<Weapon>());
        _hpBar.HealthBarSettings(_maxHealth);
    }

    private void Update()
    {
        // Test
        if (IsTestUpgradeWeapon)
        {
            IsTestUpgradeWeapon = false;
            foreach (var item in _weapons)
            {
                item.SetActive(false);
                _weapons[TestWeaponLevel].SetActive(true);
                _vfxController = null;
            }
            CurrentWeaponSettings(_weapons[TestWeaponLevel].GetComponent<Weapon>());
        }
        // Test

        if (!IsTargetSet && _targetList.Count > 0)
            LookingForTarget();
    }

    public void UpgradeWeapon(Item.ItemEnum weapon)
    {
        if (CurrentWeaponLevel < (int)weapon)
        {
            CurrentWeaponLevel = (int)weapon;

            foreach (var item in _weapons)
                item.SetActive(false);

            _weapons[CurrentWeaponLevel].SetActive(true);
            CurrentWeaponSettings(_weapons[CurrentWeaponLevel].GetComponent<Weapon>());

            _vfxController = null;
        }
    }

    private void CurrentWeaponSettings(Weapon weapon)
    {
        _animationController.ChangeAimState(weapon.IsRifleState);
        _reloading = new WaitForSeconds(weapon.AcceleratedAttackSpeed);
        _defaultAttackSpeed = new WaitForSeconds(weapon.DefaultAttackSpeed);
        _shotsCountAtTime = weapon.ShotsCountAtTime;
        _damage = weapon.Damage;
        _shootSound = weapon.GetWeaponSound;

        _weaponVFX = weapon.GetWeaponVFX;
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
        var randomDamage = UnityEngine.Random.Range(damage - 5, damage);
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
            if (Vector3.Distance(transform.position, enemy.transform.position) < _attackRange && !IsTargetSet)
            {
                IsTargetSet = true;
                _target = enemy;
                StartCoroutine(AttackCoroutine());
            }
    }

    public void Attack()
    {
        if (_isAbleToShoot && IsTargetSet && _target.CurrentHealth > 0 && CurrentHealth > 0)
        {
            if (!_isReloadingCoroutineStarted)
            {
                _isReloadingCoroutineStarted = true;
                StartCoroutine(Reloading());
            }

            for (int i = 0; i < _shotsCountAtTime; i++)
                _target.GetHit(_damage);

            _weaponVFX.Play();

            _audioSource.PlayOneShot(_shootSound);
            transform.LookAt(_target.transform.position);
        }
        else if (IsTargetSet && _target.CurrentHealth <= 0 && CurrentHealth > 0)
        {
            IsTargetSet = false;
            transform.rotation = _baseRotation;
        }
    }

    private IEnumerator Reloading()
    {
        _isAbleToShoot = false;
        yield return _reloading;
        _isAbleToShoot = true;
        _isReloadingCoroutineStarted = false;
    }

    private IEnumerator AttackCoroutine()
    {
        while (_target.CurrentHealth > 0 && IsTargetSet)
        {
            Attack();
            yield return _defaultAttackSpeed;
        }
        IsTargetSet = false;
        transform.rotation = _baseRotation;
    }
}