using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is the base class of all critters.
/// </summary>
public abstract class Critter
{
    // DISPLAY
    [SerializeField]
    GameObject _display;
    
    // STATS
    public string Name { get; }
    public int BaseHealth { get; }
    public int BaseEnergy { get; }
    public int BaseSpeed { get; }
    
    public int BaseMana { get; }

    public Character Owner { get; private set; }

    /// <summary>
    /// This is the list of actions your critter can perform in combat.
    /// </summary>
    public virtual List<CombatMove> Moveset { get; private set; }

    // CURRENT VALUES
    public int CurrentHealth { get; private set; }
    public int CurrentMana { get; private set; }
    public int CurrentSpeed { get; private set; }
    

    public List<StatusEffect> statusEffects = new ();

    
    // EVENTS
    public void Enact(ICritterBattleManager bm, int actionIndex)
    {
        if (actionIndex < 0 || actionIndex >= Moveset.Count)
        {
            Debug.LogWarning($"{Owner}.{Name}: Invalid action index.");
            Moveset[0].Invoke(bm);
            return;
        }

        var targetMove = Moveset[actionIndex];
        if(targetMove.ManaCost > CurrentMana)
        {
            // Do basic attack? Do nothing?
            return;
        }

        CurrentMana -= targetMove.ManaCost;
        targetMove.Action.Invoke(bm);
    }

    
    public virtual void OnTurn(ICritterBattleManager bm)
    {
        statusEffects.ForEach(e => e.OnTurn(bm));
        // Remove all effects whose timer has reached 0.
        statusEffects.RemoveAll((effect) => StatusEffect.RemoveCheck(bm, effect));
        
        // Display / update effect list.
    }
    
    
    public virtual void OnHit(ICritterBattleManager bm, Attack sending)
    {
        statusEffects.ForEach(eff => eff.OnHit(bm, sending));
    }
    
    
    public virtual void OnHurt(ICritterBattleManager bm, Attack receiving)
    {
        statusEffects.ForEach(eff => eff.OnHurt(bm, receiving));
        OnHurtNoEffects(receiving);
    }

    public virtual void OnHurtNoEffects(Attack receiving)
    {
        CurrentHealth -= receiving.damageAmount;
    }

    // TODO: We'll likely want OnHitLand and OnHitMiss events for things like lifesteal.
    public virtual void OnHeal(ICritterBattleManager bm, Heal heal)
    {
        CurrentHealth += heal.healAmount;
        if (CurrentHealth > BaseHealth)
        {
            CurrentHealth = BaseHealth;
        }
    }

    
    #region Effects

    //Return true if the effect wasn't already in the list.
    public bool AddEffect(ICritterBattleManager bm, StatusEffect newEffect) {
        if(!newEffect.Stackable) {

            //If the effect can't stack, check if it's already exists in the list.
            //If it is, extend the duration.
            foreach (StatusEffect effect in statusEffects) {

                //Check if any effect is of the same type (by checking if it's of the same C# class).
                if (effect.GetType() == newEffect.GetType()) {

                    //Give the effect either the sum of durations or the max duration, whichever is smaller.
                    effect.Duration = Mathf.Min(effect.Duration + newEffect.Duration, newEffect.MaxDuration);

                    return false;
                }
            }
        }

        //If the effect wasn't found or it can stack, add it to the list.
        statusEffects.Add(newEffect);
        newEffect.OnStart(bm);
        return true;
    }
    
    public bool RemoveEffect(ICritterBattleManager bm, StatusEffect effect) {
        if(statusEffects.Remove(effect))
        {
            effect.OnEnd(bm);
            return true;
        }
        return false;
    }

    #endregion
    
    // Character chooses the attack to execute, but the critter is the one to
    // enact the attack. Character.Act -> Critter.Enact -> BattleManager ->
}