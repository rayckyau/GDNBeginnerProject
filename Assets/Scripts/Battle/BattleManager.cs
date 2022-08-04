using System;

public class BattleManager : ICritterBattleManager, ICharacterBattleManager
{
    private Character[] _characters;
    private Character _currentCharacter;

    public BattleManager(Character[] characters, BattleEnvironment environment)
    {
        _characters = characters;
    }
    
    public virtual void AttackOpponent(Attack attack)
    {
        
    }

    public virtual void AttemptFlee()
    {
        
    }
}
