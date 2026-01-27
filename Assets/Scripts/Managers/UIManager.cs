using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;


public class UIManager : Singleton<UIManager>
{
    public UIElement[] UIElements; //All Elements that will need to be dynamically spawned

    public static Stack<UIElement> ElementStack = new Stack<UIElement>();

    public Canvas canvas;

    public static event Action<UIElement> OnNewElementSpawned;

    protected override void Awake()
    {
        base.Awake();
        
        //MatchManager.OnMatchExit += CloseAllElements;
    }
    private void OnDestroy()
    {
        //MatchManager.OnMatchExit -= CloseAllElements;
    }

    public static bool ElementRegistered(UIElement element)
    {
        return ElementStack.Contains(element);
    }

    public static UIElement CreateElement(string element, bool hidePrevious = false)
    {
        UIElement chosen = Array.Find(Instance.UIElements, e => e.name == element);
        if (chosen == null) return null;
        return CreateElement(chosen, hidePrevious);
    }

    public static UIElement CreateElement(UIElement element, bool hidePrevious = false)
    {
        //Maybe need to make a priority var to know what should be ontop of what, I.E pause menu always on top
        if (Instance == null) return null;

        ElementStack.TryPeek(out UIElement previous);

        UIElement spawn = Instantiate(element, Instance.canvas.transform);

        if (hidePrevious) if (previous != null) previous.gameObject.SetActive(false); //Maybe need to make all UIElements have a canvas alpha group and just set that to 0 if it makes things wonky

        OnNewElementSpawned?.Invoke(spawn);

        return spawn;
    }
    public static void RegisterElement(UIElement element)
    {
        if (ElementRegistered(element)) return;
        ElementStack.Push(element);
    }

    public static void CloseElement(UIElement element)
    {
        //Run a close sequence all UIElements implement
        if (element == null) return;
        element.CloseSelf();
        RemoveElement(element);
    }

    /// <summary>
    /// Only use manually if the Element should be force closed without care.
    /// </summary>
    /// <param name="element"></param>
    public static void RemoveElement(UIElement element)
    {
        DeregisterElement(element);
        if (element == null) return;
        Destroy(element.gameObject);
    }

    public static void DeregisterElement(UIElement element)
    {
        if (!ElementRegistered(element)) return;

        var list = ElementStack.ToList();
        list.Remove(element);

        ElementStack = new Stack<UIElement>(list);
    }

    public static UIElement PopElementStack()
    {
        ElementStack.TryPop(out var element);
        return element;
    }
    public static void CloseAllElements()
    {
        while (ElementStack.Count > 0)
        {
            RemoveElement(ElementStack.Pop());
        }
    }
}

