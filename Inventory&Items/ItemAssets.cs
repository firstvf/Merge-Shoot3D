using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    [SerializeField] private Sprite[] _weaponSprites;

    private void Awake()
    {
        Instance = this;
    }

    public Sprite GetWeaponSpriteWithValue(int value) => _weaponSprites[value];

    public Sprite Glock => _weaponSprites[0];
    public Sprite Usp => _weaponSprites[1];
    public Sprite Nova => _weaponSprites[2];
    public Sprite Pumpgun => _weaponSprites[3];
    public Sprite Spas12 => _weaponSprites[4];
    public Sprite Scorp => _weaponSprites[5];
    public Sprite Mac10 => _weaponSprites[6];
    public Sprite Mp5 => _weaponSprites[7];
    public Sprite P90 => _weaponSprites[8];
    public Sprite Vector => _weaponSprites[9];
    public Sprite Ak47 => _weaponSprites[10];
    public Sprite M16a4 => _weaponSprites[11];
    public Sprite Aug => _weaponSprites[12];
    public Sprite Hk416 => _weaponSprites[13];
    public Sprite Scar => _weaponSprites[14];
    public Sprite Tar21 => _weaponSprites[15];
    public Sprite M249 => _weaponSprites[16];
}