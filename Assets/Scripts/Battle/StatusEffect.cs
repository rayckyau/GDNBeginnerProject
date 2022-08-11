public class StatusEffect
{
    public virtual string Name => "Effect";
    public virtual int MaxDuration => int.MaxValue;
    public virtual bool Stackable => false;
    
    public int Duration { get; set; }
    public Critter Target { get; private set; }

    
    public StatusEffect(Critter target, int duration)
    {
        Target = target;
        Duration = duration;
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

    
    public virtual void OnStart() {  }
    public virtual void OnEnd() {  }

    public override string ToString() {
        return $"{Name} [ {Duration} ]";
    }
}
