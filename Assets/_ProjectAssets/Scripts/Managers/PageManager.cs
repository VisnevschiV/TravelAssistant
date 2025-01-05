using UnityEngine;

public class PageManager : MonoSingleton<PageManager>
{
    public MainPage mainPage;
    public LocationPage locationPage;
    public AudioGuidePage audioGuide;
    public MapPopUp mapPopUp;

    public void SetLocationScene(Location location)
    {
        mainPage.Deactivate();
        locationPage.Activate(location);
    }

    public void PlayAudioGuide(Location location)
    {
        audioGuide.Activate(location);
    }

    public void ShowMapPopUp(Location location)
    {
        mapPopUp.Activate(location);
    }

    public void MainPage()
    {
        mainPage.Activate();
        locationPage.Deactivate();
    }
    
    public void MapPage()
    {
        mainPage.Deactivate();
    }
}
