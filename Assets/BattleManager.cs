using System;

public interface ICharacterBattleManager
{
    public void DoActionToOtherCharacter(Action<Character> action);
    public void AttemptFlee();
}

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
