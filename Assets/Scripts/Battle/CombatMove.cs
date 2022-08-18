using UnityEngine.Events;

public struct CombatMove
{
    public UnityAction<ICritterBattleManager> Action { get; private set; }
    public int ManaCost { get; private set; }

    public CombatMove(UnityAction<ICritterBattleManager> action, int manaCost)
    {
        this.Action = action;
        this.ManaCost = manaCost;
    }


    /// <summary>
    /// Shorthand for "combatMove.Action.Invoke"
    /// </summary>
    public void Invoke(ICritterBattleManager bm)
    {
        Action.Invoke(bm);
    }
}
