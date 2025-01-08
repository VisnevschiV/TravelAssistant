using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement("LocationButton")]
public partial class LocationButton : Button
{
    public Location location;
    
    public LocationButton(Location location)
    {
        this.location = location;
        RegisterCallback<AttachToPanelEvent>(evt => Initialize());
    }
    public LocationButton()
    {
        location = new Location();   
        RegisterCallback<AttachToPanelEvent>(evt => Initialize());
    }

    private void Initialize()
    {
        LoadTree();
        SetTitle();
        SetImage();
        SetFunctionality();
    }

    private void LoadTree()
    {
        var visualTree =  Resources.Load<VisualTreeAsset>("UXML/LocationButton");
        visualTree.CloneTree(this);

        // Load USS
        var styleSheet = Resources.Load<StyleSheet>("USS/LocationButton");
        this.styleSheets.Add(styleSheet);
        this.name = "button";
    }

    private void SetTitle()
    {
        this.Q<Label>().text = location.name;
    }

    private void SetImage()
    {
        var imgElement = this.Q<VisualElement>("img");
        if (imgElement != null && location.images.Length > 0 && location.images[0] != null)
        {
            imgElement.style.backgroundImage = new StyleBackground((Background) location.images[0]);
        }
    }

    private void SetFunctionality()
    {
        this.clicked += OnClick;
    }

    private void OnClick()
    {
        PageManager.Instance.SetLocationScene(location);
    }
}
