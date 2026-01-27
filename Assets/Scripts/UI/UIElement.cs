using UnityEngine;
using System.Collections.Generic;
using System;


public abstract class UIElement : MonoBehaviour
{
    [SerializeField]
    public List<UIElement> DestructOnSpawned;
    private readonly List<Type> destructOnSpawnedTypes = new();

    private List<UIElement> children = new();

    protected virtual void Awake()
    {
        UIManager.RegisterElement(this);
        UIManager.OnNewElementSpawned += EnforceUptimeRequirements;
        foreach (object o in DestructOnSpawned)
        {
            destructOnSpawnedTypes.Add(o.GetType());
        }
    }

    public void EnforceUptimeRequirements(UIElement newElement)
    {
        if (destructOnSpawnedTypes.Contains(newElement.GetType()))
        {
            CloseSelf();
        }
    }

    /// <summary>
    /// Run any closing Logic to safely and appropriately close the UI. Not to be called on its own
    /// </summary>
    protected abstract void CloseUI();

    public void CloseSelf()
    {
        UIManager.RemoveElement(this);
        CloseUI();
    }


    protected virtual void OnDestroy()
    {
        if (UIManager.ElementRegistered(this))
        {
            print($"On destroy element was still registered");
            UIManager.DeregisterElement(this);
        }
    }

    public void CreateNewUI(string name)
    {
        UIElement el = UIManager.CreateElement(name);
        if(el != null)
        {
            children.Add(el);
        }
    }
    public void DestroyUI(UIElement element)
    {
        UIManager.CloseElement(element);
    }

    public void CollapseChildren()
    {
        foreach(UIElement el in children)
        {
            if(el == null) continue;
            el.CollapseChildren();
        }
        UIManager.CloseElement(this);
    }
}

