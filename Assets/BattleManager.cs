using System;

public class BattleManager : ICritterBattleManager, ICharacterBattleManager
{
    private Character[] _characters;
    private Character _currentCharacter;

    public BattleManager(Character[] characters, BattleEnvironment environment)
    {
        this._characters = characters;
    }

    public void AttackOpponent(Attack attack)
    {
        
    }

    public void AttemptFlee()
    {
        
    }
}
