using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M249 : Weapon
{
    public override float AcceleratedAttackSpeed { get; protected set; }
    public override float DefaultAttackSpeed { get; protected set; }
    public override int ShotsCountAtTime { get; protected set; }
    public override int Damage { get; protected set; }
    public override bool IsRifleState { get; protected set; }

    private void Awake()
    {
        AcceleratedAttackSpeed = 0.8f;
        DefaultAttackSpeed = 3.5f;
        ShotsCountAtTime = 8;
        Damage = 125;
        IsRifleState = true;
    }
}