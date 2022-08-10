 using System.Collections;
 using System.Collections.Generic;

 public interface ICharacterBattleManager : ICritterBattleManager
{
    public void AttemptFlee();
    
    
    // Exposes component to character.
    BattleManagerComponent Component { get; }
    
    // Exposes coroutines only.
    //void StartCoroutine(IEnumerator routine);
    //void StopCoroutines();
}

