using System;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    
    protected List<Critter> _critters;
    protected Critter _currentCritter;
    
    public void Act(ICharacterBattleManager bm)
    {
        OnBeforeAct(bm);
        DoAct(bm);
    }
    
    public virtual void DoAct(ICharacterBattleManager bm) { }
    protected virtual void OnBeforeAct(ICharacterBattleManager bm) { }
}
