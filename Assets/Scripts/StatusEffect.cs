public class StatusEffect
{
    public virtual bool Stackable => false;
    public virtual string Name => "Effect";
    public int Duration { get; set; }
    public Critter Target { get; private set; }

    
    public StatusEffect(Critter target, int duration)
    {
        this.Target = target;
        this.Duration = duration;
    }

    public static bool RemoveCheck(StatusEffect effect)
    {
        if (--effect.Duration <= 0) {
            effect.OnEffectEnd();
            return true;
        }
        else { return false; }
    }
    
    public virtual void AffectOnTurn() { }
    public virtual Attack AffectOnHit(Attack atk) { return atk; }
    public virtual Attack AffectOnHurt(Attack atk) { return atk; }

    public virtual void OnEffectStart() { CombatLog.Instance.Log(Target.Name + " gained " + Name); }
    public virtual void OnEffectEnd() { CombatLog.Instance.Log(Name + " has worn off."); }

    public virtual int MaxDuration() { return int.MaxValue; }
    public override string ToString() {
        return $"{Name} [ {Duration} ]";
    }
}
