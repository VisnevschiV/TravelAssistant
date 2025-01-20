using UnityEngine;
using UnityEngine.UIElements;

public class ARPage : Page
{
    [SerializeField]
    private Camera _camera;
    public void Activate()
    {
        this.gameObject.SetActive(true);
        _root.Q<Button>("back").clicked += GoBack;
        _root.Q<Button>("recordButton").clicked += StartRecording;
    }

  
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
    
    private void StartRecording()
    {
        // Start recording
    }
    
    private void StopRecording()
    {
        // Stop recording
    }
    private void GoBack()
    {
        PageManager.Instance.MainPage();
    }
}
