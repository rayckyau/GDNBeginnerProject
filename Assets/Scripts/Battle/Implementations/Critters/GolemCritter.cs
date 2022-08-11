namespace Battle.Implementations
{
    public class GolemCritter : Critter
    {
        
    }

    public class ModifyIncomingDmgEffect : StatusEffect
    {
        float m_DmgMultiplier;

        public ModifyIncomingDmgEffect(Critter target, int duration, float multiplier)
            : base(target, duration)
        {
            m_DmgMultiplier = multiplier;
        }
        
        public override string Name => "Armored";
        public override int MaxDuration => 5;
        public override Attack OnHurt(Attack atk)
        {
            atk.damageAmount = (int)(atk.damageAmount * m_DmgMultiplier);
            return base.OnHurt(atk);
        }
    }
}
