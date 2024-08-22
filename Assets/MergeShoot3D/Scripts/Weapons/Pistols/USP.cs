public class USP : Weapon
{
    public override float AcceleratedAttackSpeed { get; protected set; }
    public override float DefaultAttackSpeed { get; protected set; }
    public override int ShotsCountAtTime { get; protected set; }
    public override int Damage { get; protected set; }
    public override bool IsRifleState { get; protected set; }

    private void Awake()
    {
        AcceleratedAttackSpeed = 0.6f;
        DefaultAttackSpeed = 1.5f;
        ShotsCountAtTime = 1;
        Damage = 15;
        IsRifleState = false;
    }
}