using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MapPopUp : Page
{
    private Location _location;
    private StyleBackground _defImg;

    public void Activate(Location location)
    {
        base.Activate();
        _root.Q<Button>("close").clicked += OnClose;
        _root.Q<Button>("see").clicked += OnGoToLocation;
        _defImg = _root.Q<VisualElement>("img").style.backgroundImage;
        _location = location;
        _root.Q<Label>("title").text = _location.name;
        _root.Q<Label>("other").text = string.Join(" | ", _location.tags.Take(3));
        if (_location.images.Length > 0)
        {
            _root.Q<VisualElement>("img").style.backgroundImage = (StyleBackground)_location.images[0];
        }
       
    }
    
    public void Deactivate()
    {
        if (_root != null)
        {
            _root.Q<Button>("close").clicked -= OnClose;
            _root.Q<Button>("see").clicked -= OnGoToLocation;
        }
        base.Deactivate();
    }

    private void OnClose()
    {
        Deactivate();
        _root.Q<VisualElement>("img").style.backgroundImage = _defImg;
    }
    
    private void OnGoToLocation()
    {
        OnClose();
        PageManager.Instance.SetLocationScene(_location);
    }

}
