using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    public int AttackRange { get; private set; }

    [SerializeField] private HealthBar _hpBar;
    [SerializeField] private GameObject _parentPrefab;
    [SerializeField] private VisualEffectsController _vfx;
    [SerializeField] private EnemyAnimationController _animationController;

    private Player _player;
    private int _maxHealth;
    private int _damage;
    private WaitForSeconds _deathTimer;
    private CoinSpawner _coinSpawner;

    /// <summary>
    /// TEST variable
    /// </summary>
    public bool IsTest = false;

    private void Awake()
    {
        _deathTimer = new WaitForSeconds(1.5f);
        _player = Player.Instance;
        _damage = 9;
        _maxHealth = 200;
        IsTest = false;
        if (IsTest)
        {
            _damage = 1;
            _maxHealth = 3000;
        }
        AttackRange = 1;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void OnEnable()
    {
        transform.position = _parentPrefab.transform.position;
        CurrentHealth = _maxHealth;
        _hpBar.HealthBarSettings(_maxHealth);
        EnemyTargetList.Instance.AddToEnemyList(this);
    }

    public void Attack()
    {
        if (_player.CurrentHealth > 0)
            _player.Gethit(_damage);
        else _animationController.SetIdleTrigger();
    }

    public void GetHit(int damage)
    {
        var randomDamage = Random.Range(damage - 5, damage);
        if (CurrentHealth > 0)
        {
            CurrentHealth -= randomDamage;
            _hpBar.UpdateHealthBar(CurrentHealth, randomDamage);
            _vfx.PlayVFX();
            if (CurrentHealth <= 0)
            {
                _animationController.SetDieTrigger();
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die()
    {
        if (!IsTest)
        {
            int moneyCount = Random.Range(1, 5);
            if (_coinSpawner == null)
                _coinSpawner = CoinSpawner.Instance;
            for (int i = 0; i < moneyCount; i++)
                _coinSpawner.CreateCoinFromPool(transform.position);
        }

        yield return _deathTimer;
        _parentPrefab.SetActive(false);
    }

    private void OnDisable()
    {
        EnemyTargetList.Instance.RemoveFromEnemyList(this);
    }
}