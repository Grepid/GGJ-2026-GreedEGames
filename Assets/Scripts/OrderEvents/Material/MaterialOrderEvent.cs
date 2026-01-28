using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "OrderEvents/Material")]
public class MaterialOrderEvent : OrderEvent<Mask.Material>
{
    public Mask.Material Surplus, Shortage, Stable;

    public override Mask.Material[] MatchingValues(RequestType typeOfRequest)
    {
        switch (typeOfRequest)
        {
            case RequestType.Scarce:
                return new Mask.Material[] { Shortage };
            case RequestType.Plenty:
                return new Mask.Material[] { Surplus };

            case RequestType.StableSupply:
                return new Mask.Material[] { Stable };

            default:
                Debug.LogError($"MATERIAL MATCH REQUEST NOT OF ORDER TYPE");
                return new Mask.Material[0];
        }
    }
}
