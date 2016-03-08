using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon : BuyableItem
{
    public int horizontalForce;

    public Weapon() : base()
    {
        horizontalForce = 1000;
    }
}
