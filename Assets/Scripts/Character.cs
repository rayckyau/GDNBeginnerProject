using System;
using System.Collections.Generic;

public class Character
{
    List<Critter> _critters;
    Critter _currentCritter;

    public virtual void DoTurn(ICharacterBattleManager bm)
    {
        throw new NotImplementedException();
    }
}
