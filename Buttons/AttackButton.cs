using UnityEngine;

public class AttackButton : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = Player.Singleton;
    }

    public void AttackAcceleration()
    {
        if (_player == null)
            _player = Player.Singleton;
        _player.Attack();
    }
}