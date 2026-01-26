using UnityEngine;
using System.Collections.Generic;
using System;


public abstract class UIElement : MonoBehaviour
{
    [SerializeField]
    public List<UIElement> DestructOnSpawned;
    private readonly List<Type> destructOnSpawnedTypes = new();

    protected void Awake()
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
    public abstract void CloseUI(); //I think make Protected and just have CloseSelf() call that

    public void CloseSelf()
    {
        UIManager.CloseElement(this);
    }


    protected void OnDestroy()
    {
        if (UIManager.ElementRegistered(this))
        {
            print($"On destroy element was still registered");
            UIManager.DeregisterElement(this);
        }
    }
}

