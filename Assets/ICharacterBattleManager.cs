using System;

public interface ICharacterBattleManager
{
    public void DoActionToOtherCharacter(Action<Character> action);
    public void AttemptFlee();
}
