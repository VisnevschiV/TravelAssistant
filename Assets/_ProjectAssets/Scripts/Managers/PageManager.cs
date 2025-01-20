using System;
using UnityEngine;

public class PageManager : MonoSingleton<PageManager>
{
    [SerializeField]
    private MainPage mainPage;
    [SerializeField]
    private LocationPage locationPage;
    [SerializeField]
    private ARPage arPage;
    [SerializeField]
    private MapPage mapPage;
    [SerializeField]
    private AudioGuidePopup audioGuidePopup;
    [SerializeField]
    private MapPopUp mapPopUp;


    private void Start()
    {
        Debug.Log("Started");
        ReadAllUIDocuments();
        MainPage();
    }


    public void SetLocationScene(Location location)
    {
        DeactivateAll(); 
        locationPage.Activate(location);
    }

    public void PlayAudioGuidePupUp(Location location)
    {
        audioGuidePopup.Activate(location);
    }

    public void ShowMapPopUp(Location location)
    {
        mapPopUp.Activate(location);
    }

    public void MainPage()
    {
        DeactivateAll();
        mainPage.Activate();
    }
    
    public void MapPage()
    {
        DeactivateAll();
        mapPage.Activate();
    }
    
    private void DeactivateAll()
    {
        mainPage.Deactivate();
        locationPage.Deactivate();
        arPage.Deactivate();
        audioGuidePopup.Deactivate();
        mapPopUp.Deactivate();
        mapPage.Deactivate();
    }

    private void ReadAllUIDocuments()
    {
        
    }
}
