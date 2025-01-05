using System;
using System.Collections.Generic;
using Mapbox.Examples;
using NUnit.Framework;
using UnityEngine;


public class DataManager : MonoSingleton<DataManager>
{
    public LocationData locationData;
    [SerializeField]
    private SpawnOnMap _spawnOnMap;

    private void Start()
    {
        List<Location> locations = new List<Location>();

        foreach (var loc in locationData.locations)
        {
            if (loc.mapPosition!="")
            {
                locations.Add(loc);
            }
        }
        
        _spawnOnMap.Init(locations);
    }

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
