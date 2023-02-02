public class M16A4 : Weapon
{
    public override float AcceleratedAttackSpeed { get; protected set; }
    public override float DefaultAttackSpeed { get; protected set; }
    public override int ShotsCountAtTime { get; protected set; }
    public override int Damage { get; protected set; }
    public override bool IsRifleState { get; protected set; }

    private void Awake()
    {
        AcceleratedAttackSpeed = 0.6f;
        DefaultAttackSpeed = 2f;
        ShotsCountAtTime = 3;
        Damage = 110;
        IsRifleState = true;
    }
}