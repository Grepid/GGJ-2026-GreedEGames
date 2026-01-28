using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="OrderEvents/Fashionable")]
public class FashionableOrderEvent : OrderEvent<Mask.Base>
{
    public Mask.Base[] Fashionable, NotFashionable;
    public override Mask.Base[] MatchingValues(RequestType typeOfRequest)
    {
        switch (typeOfRequest)
        {
            case RequestType.Fashionable:
                return Fashionable;
            case RequestType.NotFashionable:
                return NotFashionable;

            default:
                Debug.LogError($"MATERIAL MATCH REQUEST NOT OF ORDER TYPE");
                return new Mask.Base[0];
        }
    }
}
