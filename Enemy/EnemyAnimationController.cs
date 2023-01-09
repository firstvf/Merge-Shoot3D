using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private const string IDLE = "Idle";
    private const string ATTACK = "Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIdleTrigger()
    {
        _animator.SetTrigger(IDLE);
    }

    public void SetAttackTrigger()
    {
        _animator.SetTrigger(ATTACK);
    }
}