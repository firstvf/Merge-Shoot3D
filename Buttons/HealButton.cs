using TMPro;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    private Player _player;
    private int _healCount = 1;
    private TextMeshProUGUI _countText;

    private void Awake()
    {
        _countText = GetComponentInChildren<TextMeshProUGUI>();
        _countText.SetText(_healCount.ToString());
    }

    public void HealPlayer()
    {
        if (_healCount > 0)
        {
            if (_player == null)
                _player = Player.Singleton;
            _player.Heal();
            _healCount--;
            _countText.SetText(_healCount.ToString());
        }
    }
}