using System.Collections;
using UnityEngine;

public class BattleManagerComponent : MonoBehaviour
{
    private BattleManager _battleManager;
    
    // Start is called before the first frame update
    private void Start()
    {
        _battleManager = new BattleManager(this, BattleSceneInitData.PlayerCharacter, BattleSceneInitData.EnemyCharacter, BattleSceneInitData.Environment);
    }
}
