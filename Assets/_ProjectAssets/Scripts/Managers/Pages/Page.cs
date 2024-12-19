using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Page : MonoBehaviour, IPage
{
    protected VisualElement _root;

    protected void OnEnable()
    {
       _root = GetComponent<UIDocument>().rootVisualElement;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
