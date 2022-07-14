using System.Collections.Generic;

public abstract class Character
{
    List<Critter> _critters;
    Critter _currentCritter;

    public abstract void DoTurn(ICharacterBattleManager bm);
}
