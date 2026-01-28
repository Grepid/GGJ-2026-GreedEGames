using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public abstract class OrderEvent<T> : ScriptableObject where T : Enum
{
    public enum RequestType
    {
        Scarce,
        Plenty,
        StableSupply,

        Fashionable,
        NotFashionable
    }

    //public T MaskPiece;
    public GameObject HintPoster;
    public OrderEvent()
    {
        if(typeof(T).DeclaringType != typeof(Mask))
        {
            Debug.LogError($"Cannot create an OrderEvent with type {typeof(T)} as it is not a Mask Enum");
        }
    }

    public abstract T[] MatchingValues(RequestType typeOfRequest);

    public bool IsCorrect(T playerChoice,RequestType requestType)
    {
        return MatchingValues(requestType).Contains(playerChoice);
    }
}


