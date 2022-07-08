using System;

public class BattleManager : ICharacterBattleManager
{
    private Character[] characters;

    public BattleManager(Character[] _characters, BattleEnvironment environment)
    {
        characters = _characters;
    }

    public void DoActionToOtherCharacter(Action<Character> action)
    {
        
    }

    public void AttemptFlee()
    {
        
    }
}
