using UnityEngine;

public class PageManager : MonoSingleton<PageManager>
{
    public MainPage mainPage;
    public LocationPage locationPage;
    public AudioGuidePage audioGuide;

    public void SetLocationScene(Location location)
    {
        mainPage.Deactivate();
        locationPage.Activate(location);
    }

    public void PlayAudioGuide(Location location)
    {
        audioGuide.Activate(location);
    }
    public void MainPage()
    {
        mainPage.Activate();
        locationPage.Deactivate();
    }
}
