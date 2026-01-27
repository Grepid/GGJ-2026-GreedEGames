using UnityEngine;

public class Mask : MonoBehaviour
{
    #region PieceTypes
    public enum Base
    {
        Square,
        Small,
        Simple
    }

    public enum Material
    {
        Iron,
        Silver,
        Gold
    }

    public enum Feather
    {
        Red,
        White,
        Black,
        Purple,
        Yellow
    }

    public enum Embelishment
    {

    }
    #endregion

    public Base BaseType;
    public Material MaterialType;
    public Feather FeatherType;
}
