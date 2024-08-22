using UnityEngine;

public class AttackButton : MonoBehaviour
{
    private Player _player;
    private bool _isAbleToAutoAttack;

    private void Start()
    {
        _player = Player.Instance;
    }

    private void Update()
    {
        if (_isAbleToAutoAttack && _player.IsTargetSet)
            AttackAcceleration();
    }

    public void AttackAcceleration()
    {
        _player.Attack();
    }

    public void PointerDown()
    {
        if (_player == null)
            _player = Player.Instance;
        _isAbleToAutoAttack = true;
    }

    public void PointerUp()
    {
        _isAbleToAutoAttack = false;
    }
}