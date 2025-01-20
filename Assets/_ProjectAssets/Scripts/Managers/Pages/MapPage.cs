using UnityEngine;
using UnityEngine.UIElements;

public class MapPage : Page
{
    
    public void Activate()
    {
        base.Activate();
        _root.Q<Button>("close").clicked += OnClose;
    }
    
    public void Deactivate()
    {
        if (_root != null)
        {
            _root.Q<Button>("close").clicked -= OnClose;
        }
        base.Deactivate();
    }
    
    private void OnClose()
    {
        PageManager.Instance.MainPage();
    }
}
