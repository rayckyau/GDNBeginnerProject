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
            effect.OnEnd();
            return true;
        }
        else { return false; }
    }
    
    public virtual void OnTurn() { }
    public virtual Attack OnHit(Attack atk) { return atk; }
    public virtual Attack OnHurt(Attack atk) { return atk; }

    public virtual void OnStart() { CombatLog.Instance.Log(Target.Name + " gained " + Name); }
    public virtual void OnEnd() { CombatLog.Instance.Log(Name + " has worn off."); }

    public virtual int MaxDuration => int.MaxValue;
    public override string ToString() {
        return $"{Name} [ {Duration} ]";
    }
}
