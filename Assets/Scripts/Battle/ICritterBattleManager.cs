public interface ICritterBattleManager
{
    public void SendAttack(Attack attack);
    public void SendAttackNoEffect(Attack attack);
    public void SendHeal(Heal heal);
    public Critter CurrentCritter { get; }
    public Critter OpponentCritter { get; }
}
