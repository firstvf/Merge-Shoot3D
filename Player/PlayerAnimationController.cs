using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private const string RUN = "Run";
    private const string AIM = "Aim";
    private const string DIE = "Die";
    private const string IDLE = "Idle";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeAimState(bool isRifleState)
    {
        _animator.SetBool("IsRifleState", isRifleState);
    }

    public void SetIdleTrigger()
    {
        _animator.SetBool(RUN, false);
        _animator.SetBool(AIM, false);
        _animator.SetBool(IDLE, true);
    }

    public void SetAimTrigger()
    {
        _animator.SetBool(RUN, false);
        _animator.SetBool(AIM, true);
    }

    public void SetDieTrigger()
    {
        _animator.SetTrigger(DIE);
    }

    public void SetRunTrigger()
    {
        _animator.SetBool(AIM, false);
        _animator.SetBool(RUN, true);
    }
}