using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    public int AttackRange { get; private set; }

    [SerializeField] private HealthBar _hpBar;
    [SerializeField] private GameObject _parentPrefab;

    private Player _player;
    private int _maxHealth;
    private int _damage;
    private EnemyAnimationController _animationController;
    private WaitForSeconds _deathTimer;
    private CoinSpawner _coinSpawner;

    private void Awake()
    {
        _deathTimer = new WaitForSeconds(1.5f);
        _animationController = GetComponent<EnemyAnimationController>();
        _player = Player.Singleton;
        _damage = 9;
        _maxHealth = 100;
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
        EnemyTargetList.Singleton.AddToEnemyList(this);
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
            if (CurrentHealth <= 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Die");
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die()
    {
        if (_coinSpawner == null)
            _coinSpawner = CoinSpawner.Singleton;
        _coinSpawner.CreateCoinFromPool(transform.position);
        yield return _deathTimer;
        _parentPrefab.SetActive(false);
    }

    private void OnDisable()
    {
        EnemyTargetList.Singleton.RemoveFromEnemyList(this);
    }
}