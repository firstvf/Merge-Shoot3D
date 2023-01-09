using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAnimationController _animationController;
    private Player _player;
    private Enemy _enemy;
    private bool _isAbleToMove;

    private void Awake()
    {
        _animationController = GetComponent<EnemyAnimationController>();
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        if (_player == null)
            _player = Player.Singleton;
        _isAbleToMove = true;
    }

    private void OnEnable()
    {
        if (_player == null)
            _player = Player.Singleton;
        _isAbleToMove = true;

    }
    private void Update()
    {
        if (_isAbleToMove)
            Movement();
    }

    private void Movement()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) > _enemy.AttackRange && _enemy.CurrentHealth > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, 0.5f * Time.deltaTime);
            transform.LookAt(_player.transform.position);
        }
        else if (Vector3.Distance(transform.position, _player.transform.position) <= _enemy.AttackRange && _enemy.CurrentHealth > 0)
            _animationController.SetAttackTrigger();
    }
    private void OnDisable()
    {
        _isAbleToMove = false;
    }
}