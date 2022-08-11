using System;

public class BattleManager :  ICharacterBattleManager, ICritterBattleManager
{
    // Should we couple the component and battle manager?
    public BattleManagerComponent Component { get; }
    
    private Character[] _characters;
    private Character _currentCharacter;

    public BattleManager(BattleManagerComponent component, Character[] characters, BattleEnvironment environment)
    {
        _characters = characters;
        Component = component;
    }

    public void OnTurn()
    {
        _currentCharacter.DoAct(this);
    }
    
    public void AttackOpponent(Attack attack)
    {
        
    }

    public void AttemptFlee()
    {
        
    }

}
