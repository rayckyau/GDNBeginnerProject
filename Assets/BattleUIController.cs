using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{
    [SerializeField]
    public Button[] optionButtons;
    [SerializeField]
    public ScrollRect itemList;
    
    public CombatMenu mainCombatMenu;
    public CombatMenu secondCombatMenu;
    public CombatMenu itemCombatMenu;

    public void LoadAndRenderMenu(CombatMenu menu)
    {
        UnbindListeners();
        for (int i=0; i < menu.menuNames.Length; i++)
        {
            if (menu.menuNames[i] == null)
            {
                optionButtons[i].gameObject.SetActive(false);
            }
            else
            {
                optionButtons[i].gameObject.SetActive(true);
                ChangeTextOnButton(i, menu.menuNames[i]);
                if (i==0)
                    optionButtons[i].onClick.AddListener(menu.Option1OnClick);
                else if (i==1)
                    optionButtons[i].onClick.AddListener(menu.Option2OnClick);
                else if (i==2)
                    optionButtons[i].onClick.AddListener(menu.Option3OnClick);
                else if (i==3)
                    optionButtons[i].onClick.AddListener(menu.Option4OnClick);
            }
        }
    }

    private void UnbindListeners()
    {
        for (int i=0; i < optionButtons.Length; i++)
        {
            optionButtons[i].onClick.RemoveAllListeners();
        }
    }

    private void ChangeTextOnButton(int buttonIndex, string newName)
    {
        var text = optionButtons[buttonIndex].gameObject.GetComponentInChildren<TextMeshProUGUI>();
        text.SetText(newName);
    }

    private void HideAllButtons()
    {
        foreach (Button b in optionButtons)
        {
            b.gameObject.SetActive(false);
        }
    }
    private void InitButtons()
    {
        optionButtons = new Button[4];
        var buttons = GetComponentsInChildren<Button>();

        if (buttons == null)
        {
            throw new Exception("no buttons in hierarchy");
        }

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i] = buttons[i];
        }
        
        HideAllButtons();
    }
    
    void Start()
    {
        InitButtons();

        mainCombatMenu = new MainCombatMenu(this);
        secondCombatMenu = new SecondCombatMenu(this);
        itemCombatMenu = new ItemCombatMenu(this);
        LoadAndRenderMenu(mainCombatMenu);
    }

    void Update()
    {
    }
}
