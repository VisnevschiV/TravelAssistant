using UnityEngine;

public class MapMarker : MonoBehaviour
{
    public Location myLocation;

    public void SetLocation(Location location)
    {
        myLocation = location;
    }
    public void OnClick()
    {
        PageManager.Instance.ShowMapPopUp(myLocation);
    }
}
