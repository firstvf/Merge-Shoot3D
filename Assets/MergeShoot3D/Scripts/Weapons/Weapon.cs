using UnityEngine;
using UnityEngine.VFX;

public abstract class Weapon : MonoBehaviour
{
    abstract public int Damage { get; protected set; }
    abstract public float DefaultAttackSpeed { get; protected set; }
    abstract public float AcceleratedAttackSpeed { get; protected set; }
    abstract public bool IsRifleState { get; protected set; }
    abstract public int ShotsCountAtTime { get; protected set; }

    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private VisualEffect _weaponVFX;

    public VisualEffect GetWeaponVFX => _weaponVFX;
    public AudioClip GetWeaponSound => _shootSound;
}