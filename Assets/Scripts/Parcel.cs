using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel
{
    public enum Types
    {
        None,
        Culture,
        Actioneur
    }

    public Types Type;

    public Parcel()
    {
        Type = Types.None;
    }
}
