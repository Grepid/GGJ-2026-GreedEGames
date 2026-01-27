using UnityEngine;
using System.Collections.Generic;

public class Customer : MonoBehaviour
{
    public enum Type
    {
        RichLady,
        OldMan,
        Soldier,
        Servant,
        Criminal
    }
    public CustomerOrder Order;
}
