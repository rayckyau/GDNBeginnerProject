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

    /// <summary>
    /// This is the list of actions your critter can perform in combat.
    /// </summary>
    public virtual List<UnityAction> Moveset { get; private set; }

    // CURRENT VALUES
    public int Health { get; private set; }
    public int Energy { get; private set; }
    public int Speed { get; set; }

    public List<StatusEffect> statusEffects = new ();

    
    // EVENTS
    public abstract void Act(ICritterBattleManager bm);

    public virtual void OnTurn()
    {
        statusEffects.ForEach(e => e.AffectOnTurn());
        // Remove all effects whose timer has reached 0.
        statusEffects.RemoveAll(StatusEffect.RemoveCheck);
        
        // Display / update effect list.
    }

    
    public virtual void OnHurt(Attack receiving, bool applyEffects = true)
    {
        if (applyEffects)
        {
            statusEffects.ForEach(eff => eff.AffectOnHurt(receiving));
        }

        Health -= receiving.damageAmount;
    }
    
    public virtual void OnHit(Attack sending, bool applyEffects = true)
    {
        if (applyEffects)
        {
            statusEffects.ForEach(eff => eff.AffectOnHit(sending));
        }
    }

    public virtual void OnHeal(Heal heal)
    {
        Health += heal.healAmount;
        if (Health > BaseHealth)
        {
            Health = BaseHealth;
        }
    }

    #region Effects

    //Return true if the effect wasn't already in the list.
    public bool AddEffect(StatusEffect newEffect) {
        if(!newEffect.Stackable) {

            //If the effect can't stack, check if it's already exists in the list.
            //If it is, extend the duration.
            foreach (StatusEffect effect in statusEffects) {

                //Check if any effect is of the same type (by checking if it's of the same C# class).
                if (effect.GetType() == newEffect.GetType()) {

                    //Give the effect either the sum of durations or the max duration, whichever is smaller.
                    effect.Duration = Mathf.Min(effect.Duration + newEffect.Duration, newEffect.MaxDuration());

                    return false;
                }
            }
        }

        //If the effect wasn't found or it can stack, add it to the list.
        statusEffects.Add(newEffect);
        newEffect.OnEffectStart();
        return true;
    }
    
    public bool RemoveEffect(StatusEffect effect) {
        return statusEffects.Remove(effect);
    }

    #endregion
    
    // Character chooses the attack to execute, but the critter is the one to
    // enact the attack. Character.Act -> Critter.Enact -> BattleManager ->
}