using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Battle.Implementations
{
    public class GolemCritter : Critter
    {
        float m_ArmorDamageMultiplier;
        int m_ModifyDamageDuration;

        int m_CounterHitDamage;
        
        public override List<CombatMove> Moveset => new()
        {
            new CombatMove(BasicAttack, 0),
            new CombatMove(ApplyArmored, 24),
            new CombatMove(Reform, 40),
            new CombatMove(ApplyCounter, 33)
        };

        void BasicAttack(ICritterBattleManager bm)
        {
            var attack = new Attack(7, bm.OpponentCritter, this);
            bm.SendAttack(attack);
        }

        void ApplyArmored(ICritterBattleManager bm)
        {
            AddEffect(bm, new ModifyIncomingDmgEffect(this, m_ModifyDamageDuration, m_ArmorDamageMultiplier));
        }

        void Reform(ICritterBattleManager bm)
        {
            var heal = new Heal(10, this, this);
            bm.SendHeal(heal);
        }
        
        // Meant to be used when the opponent has no mana for any move, meaning they have to attack.
        void ApplyCounter(ICritterBattleManager bm)
        {
            AddEffect(bm, new CounterNextHitEffect(this, 1, m_CounterHitDamage));
        }
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
        public override Attack OnHurt(ICritterBattleManager bm, Attack atk)
        {
            atk.damageAmount = (int)(atk.damageAmount * m_DmgMultiplier);
            return base.OnHurt(bm, atk);
        }
    }


    public class CounterNextHitEffect : StatusEffect
    {
        int m_CounterDamage;

        public CounterNextHitEffect(Critter target, int duration, int counterDamage)
            : base(target, duration)
        {

            m_CounterDamage = counterDamage;
        }

        public override string Name => "Counter";
        public override int MaxDuration => 1;
        public override Attack OnHurt(ICritterBattleManager bm, Attack atk)
        {
            atk.damageAmount = 0;

            var counterAtk = new Attack(m_CounterDamage, atk.sender, Target);
            bm.SendAttack(counterAtk);

            return base.OnHurt(bm, atk);
        }
    }
}
