using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SecondCombatMenu : CombatMenu
{
    public SecondCombatMenu(BattleUIController uiCont) : base(uiCont)
    {
        menuNames = new string[]{"Test1", null, null, "Back"};

        Option1OnClick = () =>
        {
            Debug.Log("Test1");
            uiController.LoadAndRenderMenu(uiCont.secondCombatMenu);
        };

        
        Option4OnClick = () =>
        {
            Debug.Log("Back");
            uiController.LoadAndRenderMenu(uiCont.mainCombatMenu);
        };

    }
    
}