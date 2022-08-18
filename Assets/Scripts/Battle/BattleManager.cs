using System;
using Random = UnityEngine.Random;

public class BattleManager :  ICharacterBattleManager, ICritterBattleManager
{
    // Should we couple the component and battle manager?
    public BattleManagerComponent Component { get; }
    
    private Character m_PlayerCharacter;
    private Character m_EnemyCharacter;

    // Reference to the critter whose turn it is.
    public Critter CurrentCritter { get; protected set; }
    // Reference to the critter who is not playing.
    public Critter OpponentCritter { get; protected set; }

    float m_EscapeChance;

    public BattleManager(BattleManagerComponent component, Character playerCharacter, Character opponentCharacter, BattleEnvironment environment)
    {
        m_PlayerCharacter = playerCharacter;
        m_EnemyCharacter = opponentCharacter;
        Component = component;
    }

    public void OnTurn()
    {
        m_PlayerCharacter.Act(this);
    }
    
    public void SendAttack(Attack attack)
    {
        attack.target.OnHurt(this, attack);
    }

    public void SendAttackNoEffects(Attack attack)
    {
        attack.target.OnHurtNoEffects(attack);
    }
    
    public void SendHeal(Heal heal)
    {
        heal.target.OnHeal(this, heal);
    }
    
    public void AttemptFlee()
    {
        if (Random.value < m_EscapeChance)
        {
            Flee();
        }
    }

    void Flee() { }

    public void SendAttackNoEffect(Attack attack)
    {
        throw new NotImplementedException();
    }
}
