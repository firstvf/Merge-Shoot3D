public class Vector : Weapon
{
    public override float AcceleratedAttackSpeed { get; protected set; }
    public override float DefaultAttackSpeed { get; protected set; }
    public override int ShotsCountAtTime { get; protected set; }
    public override int Damage { get; protected set; }
    public override bool IsRifleState { get; protected set; }

    private void Awake()
    {
        AcceleratedAttackSpeed = 0.35f;
        DefaultAttackSpeed = 1f;
        ShotsCountAtTime = 6;
        Damage = 25;
        IsRifleState = true;
    }
}