using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Singleton { get; private set; }
    [SerializeField] private Sprite _pistol, _nova, _shotgun, _uzi, _ump, _ak47, _m4a4;

    public Sprite Pistol => _pistol;
    public Sprite Nova => _nova;
    public Sprite Shotgun => _shotgun;
    public Sprite Uzi => _uzi;
    public Sprite Ump => _ump;
    public Sprite Ak47 => _ak47;
    public Sprite M4a4 => _m4a4;

    private void Awake()
    {
        Singleton = this;
    }
}