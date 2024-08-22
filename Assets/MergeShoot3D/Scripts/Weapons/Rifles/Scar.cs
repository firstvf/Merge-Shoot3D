public class Scar : Weapon
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
        ShotsCountAtTime = 4;
        Damage = 125;
        IsRifleState = true;
    }
}