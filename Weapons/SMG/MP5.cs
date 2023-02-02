public class MP5 : Weapon
{
    public override float AcceleratedAttackSpeed { get; protected set; }
    public override float DefaultAttackSpeed { get; protected set; }
    public override int ShotsCountAtTime { get; protected set; }
    public override int Damage { get; protected set; }
    public override bool IsRifleState { get; protected set; }

    private void Awake()
    {
        AcceleratedAttackSpeed = 0.75f;
        DefaultAttackSpeed = 1.2f;
        ShotsCountAtTime = 7;
        Damage = 35;
        IsRifleState = true;
    }
}