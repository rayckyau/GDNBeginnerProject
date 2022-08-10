using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.Implementations.Characters
{
    public class RandomChoiceCharacter : Character
    {
        // Chooses a random move.
        public override void Act(ICharacterBattleManager bm)
        {
            base.Act(bm);

            bm.Component.StartCoroutine(new WaitForSecondsRealtime(1f));
            
            int choice = Random.Range(0, _currentCritter.Moveset.Count);
            _currentCritter.Enact(choice, bm);
        }
    }
}
