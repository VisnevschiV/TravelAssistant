using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[UxmlElement("LocationsList")]
public partial class LocationsList : VisualElement
{
    [UxmlAttribute]
    public LocationTag tag = LocationTag.popular;
    public LocationsList()
    {
        RegisterCallback<AttachToPanelEvent>(evt => Initialize());
    }

    public LocationsList(LocationTag newTag)
    {
        tag = newTag;
        RegisterCallback<AttachToPanelEvent>(evt => Initialize());
    }

    private void Initialize()
    {
        LoadTree();
        SetTitle();
        SetLocations();
    }

    private void LoadTree()
    {
        var visualTree = Resources.Load<VisualTreeAsset>("UXML/LocationsList");
        visualTree.CloneTree(this);

        // Load USS
        var styleSheet = Resources.Load<StyleSheet>("USS/LocationsList");
        this.styleSheets.Add(styleSheet);
        this.name = "LocationsList";
        this.AddToClassList("scrollContainer");
    }
    
    private void SetTitle()
    {
        this.Q<Label>("title").text = tag.ToString();
    }
    
    private void SetLocations()
    {
        ScrollView scrollView = this.Q<ScrollView>();
        scrollView.Clear();
        foreach (var location in DataManager.Instance.GetLocationsWithTag(tag))
        {
            scrollView.Add(new LocationButton(location));
        }
    }

    
}
