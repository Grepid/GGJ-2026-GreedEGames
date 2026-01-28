using UnityEngine;
using System;
using System.Collections.Generic;

public class OrderEventManager : Singleton<OrderEventManager>
{
    //TODO
    //Might need to make every single event type have a list and current
    //Might also need to make it so it picks a certain version and they all stick with it. So it will always pick [x] to allow them to align, assuming Fash + Ban requests align to allow every combo
    //With Fashionable + Banned combo, I might need to create some form of ma


    public MaterialOrderEvent[] MaterialOrderEvents;
    public MaterialOrderEvent CurrentMaterialOrderEvent;

    public FashionableOrderEvent[] FashionableOrderEvents;
    public FashionableOrderEvent CurrentFashionableOrderEvent;

    protected override void Awake()
    {
        base.Awake();
        CurrentMaterialOrderEvent = Grepid.BetterRandom.Rand.RandFromCollection(MaterialOrderEvents);
        CurrentFashionableOrderEvent = Grepid.BetterRandom.Rand.RandFromCollection(FashionableOrderEvents);

        print($"Chosen Material Event:\nSurplus: {CurrentMaterialOrderEvent.Surplus}\nShortage: {CurrentMaterialOrderEvent.Shortage}\nStable: {CurrentMaterialOrderEvent.Stable}");
    }
}
