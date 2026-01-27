using System;
using UnityEngine;
using System.Collections.Generic;

public class CustomerOrder
{
    public Tuple<OrderDifficulty,Mask.Base> BaseType;
    public Tuple<OrderDifficulty,Mask.Material> MaterialType;
    public Tuple<OrderDifficulty, Mask.Feather> FeatherType;

    public string OrderText;
    public string BaseHint;
    public string MaterialHint;
    public string FeatherHint;

    public CustomerOrder(Tuple<OrderDifficulty,Mask.Base> BaseConfig,Tuple<OrderDifficulty,Mask.Material> MaterialConfig, Tuple<OrderDifficulty,Mask.Feather> FeatherConfig)
    {
        BaseType = BaseConfig;
        MaterialType = MaterialConfig;
        FeatherType = FeatherConfig;

        GenerateOrderText();
    }

    private void GenerateOrderText()
    {
        BaseHint = Grepid.BetterRandom.Rand.RandFromCollection(CustomerOrderGenerator.MaskBaseRequests[BaseType.Item1][BaseType.Item2]);
        MaterialHint = Grepid.BetterRandom.Rand.RandFromCollection(CustomerOrderGenerator.MaskMaterialRequests[MaterialType.Item1][MaterialType.Item2]); 
        FeatherHint = Grepid.BetterRandom.Rand.RandFromCollection(CustomerOrderGenerator.MaskFeatherRequests[FeatherType.Item1][FeatherType.Item2]);

        string combined = $"{BaseHint}. {MaterialHint}. And {FeatherHint}";
        OrderText = combined;
    }
}
