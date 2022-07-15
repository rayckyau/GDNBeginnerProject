using System;
using UnityEngine.Events;

public abstract class CombatMenu
{
    public string[] menuNames;

    public UnityAction Option1OnClick;
    public UnityAction Option2OnClick;
    public UnityAction Option3OnClick;
    public UnityAction Option4OnClick;
}