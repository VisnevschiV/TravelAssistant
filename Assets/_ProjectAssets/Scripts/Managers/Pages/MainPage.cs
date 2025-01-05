using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class MainPage : Page
{
    private void Start()
    {
        _root.Q<Button>("map").clicked += Map;
    }

    private void Map()
    {
        PageManager.Instance.MapPage();
    }   

    private void OnEnable()
    {
        base.OnEnable();
    }
}
