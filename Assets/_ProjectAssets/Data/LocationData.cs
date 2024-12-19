using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public enum LocationTag{
    popular,
    historical,
    artistical,
    
}

[Serializable]
public class Location
{
    public string name;
    public string description;
    public Texture[] images;
    public AudioClip audioGuide;
    public string[] audioTranscript;
    public GameObject arExperience;
    [SerializeField]
    public List<LocationTag> tags;
    public bool isLiked;
}

[CreateAssetMenu(fileName = "LocationData", menuName = "LocationData")]
public class LocationData : ScriptableObject
{
    public List<Location> locations = new List<Location>();
}
