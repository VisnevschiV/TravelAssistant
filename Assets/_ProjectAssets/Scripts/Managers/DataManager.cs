using System.Collections.Generic;
using NUnit.Framework;


public class DataManager : MonoSingleton<DataManager>
{
    public LocationData locationData;

    public List<Location> GetLocationsWithTag(LocationTag tag)
    {
        List<Location> locationsWithTag = new List<Location>();

        foreach (var location in locationData.locations)
        {
            if (location.tags.Contains(tag))
            {
                locationsWithTag.Add(location);
            }
        }

        return locationsWithTag;
    }
}
