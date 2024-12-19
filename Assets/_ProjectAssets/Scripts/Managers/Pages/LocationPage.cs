using System;
using UnityEngine;
using UnityEngine.UIElements;

public class LocationPage : Page
{
    [SerializeField]
    private Texture2D liked, unliked;
    private Location currentLocation = new Location();

    public void Activate(Location location)
    {
        currentLocation = location;
        this.gameObject.SetActive(true);
        _root.Q<Label>("title").text = location.name;
        var imgElement = _root.Q<VisualElement>("img");
        if (imgElement != null && location.images.Length > 0 && location.images[0] != null)
        {
            imgElement.style.backgroundImage = new StyleBackground((Background) location.images[0]);
        }

        _root.Q<Label>("info").text = location.description;
        SetUp();
    }

    private void SetUp()
    {

        _root.Q<Button>("ar").style.display = 
            currentLocation.arExperience != null 
                ? DisplayStyle.Flex 
                : DisplayStyle.None;
        
        _root.Q<Button>("audio").style.display =
            currentLocation.audioGuide != null 
                ? DisplayStyle.Flex 
                : DisplayStyle.None;

        _root.Q<Button>("like").style.backgroundImage = 
            currentLocation.isLiked
            ? new StyleBackground(liked)
            : new StyleBackground(unliked);
        
        _root.Q<Button>("GetDirections").clicked += GetDirections;
        _root.Q<Button>("back").clicked += GoBack;
        _root.Q<Button>("like").clicked += Like;
        _root.Q<Button>("ar").clicked += AR;
        _root.Q<Button>("audio").clicked += AudioGuide;

    }

    private void GoBack()
    {
        PageManager.Instance.MainPage();
    }

    private void GetDirections()
    {
        
    }

    private void AR()
    {
        
    }

    private void AudioGuide()
    {
        PageManager.Instance.PlayAudioGuide(currentLocation);
    }

    private void Like()
    {
        currentLocation.isLiked = !currentLocation.isLiked;
        _root.Q<Button>("like").style.backgroundImage = 
            currentLocation.isLiked
                ? new StyleBackground(liked)
                : new StyleBackground(unliked);
    }
}
