using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainCombatMenu : CombatMenu
{
    private BattleUIController uiController;
    public MainCombatMenu(BattleUIController uiCont)
    {
        uiController = uiCont;
        menuNames = new string[]{"Attack", "Defense", "Item", "Stats"};

        Option1OnClick = () =>
        {
            Debug.Log("attack");
            uiController.LoadAndRenderMenu(uiCont.secondCombatMenu);
        };
        
        Option2OnClick = () =>
        {
            Debug.Log("Defense");
        };
        
        Option3OnClick = () =>
        {
            Debug.Log("Item");
            uiCont.itemList.gameObject.SetActive(true);
            uiController.LoadAndRenderMenu(uiCont.itemCombatMenu);
        };
        
        Option4OnClick = () =>
        {
            Debug.Log("Stats");
        };
    }
    
}