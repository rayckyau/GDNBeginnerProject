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

    public static bool RemoveCheck(ICritterBattleManager bm, StatusEffect effect)
    {
        if (--effect.Duration <= 0) {
            effect.OnEnd(bm);
            return true;
        }
        else { return false; }
    }
    
    public virtual void OnTurn(ICritterBattleManager bm) { }
    public virtual Attack OnHit(ICritterBattleManager bm, Attack atk) { return atk; }
    public virtual Attack OnHurt(ICritterBattleManager bm, Attack atk) { return atk; }

    
    public virtual void OnStart(ICritterBattleManager bm) {  }
    public virtual void OnEnd(ICritterBattleManager bm) {  }

    public override string ToString() {
        return $"{Name} [ {Duration} ]";
    }
}
