using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    
    protected List<Critter> _critters;
    protected Critter _currentCritter;
    
    public virtual void Act(ICharacterBattleManager bm)
    {
        OnAct();
    }

    protected virtual void OnAct() { }
}
