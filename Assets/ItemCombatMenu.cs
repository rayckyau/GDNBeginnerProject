using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemCombatMenu : CombatMenu
{
    private BattleUIController uiController;
    public ItemCombatMenu(BattleUIController uiCont)
    {
        uiController = uiCont;
        menuNames = new string[]{null, null, "Use", "Back"};

        Option3OnClick = () =>
        {
            Debug.Log("Use Item");
        };

        
        Option4OnClick = () =>
        {
            Debug.Log("Back");
            uiCont.itemList.gameObject.SetActive(false);
            uiController.LoadAndRenderMenu(uiCont.mainCombatMenu);
        };

    }
    
}