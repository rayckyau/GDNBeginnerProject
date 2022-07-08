using System;

public class BattleManager : ICharacterBattleManager
{
    private Character[] _characters;
    private Character _character;

    public BattleManager(Character[] characters, BattleEnvironment environment)
    {
        this._characters = characters;
    }

    public void AttackOpponent(Attack attack)
    {
        _character.ApplyAttack(attack);
    }

    public void AttemptFlee()
    {
        
    }
}
