using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class MainPage : Page
{
    public new void Activate()
    {
        base.Activate();
        _root.Q<Button>("map").clicked += Map;
    }
    
    public new void Deactivate()
    {
        _root.Q<Button>("map").clicked -= Map;
        base.Deactivate();
    }

    private void Map()
    {
        PageManager.Instance.MapPage();
    }
}
