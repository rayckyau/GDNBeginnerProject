using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Implementations.Characters
{
    public class PlayableCharacter : Character
    {
        bool _hasChosen;
        int _choice;

        public override void Act(ICharacterBattleManager bm)
        {
            base.OnAct();
            
            _hasChosen = false;
            bm.Component.StartCoroutine(new WaitUntil(WaitForUser));
            
            _currentCritter.Enact(_choice, bm);
        }

        bool WaitForUser() => _hasChosen;

        public void ChooseCritterAction(int index)
        {
            _choice = index;
            _hasChosen = true;
        }
    }
}
