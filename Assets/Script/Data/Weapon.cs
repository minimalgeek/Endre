using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{

    public int id;
    public int price;
    public long horizontalForce;

    public Weapon()
    {
        id = 0;
        price = 0;
        horizontalForce = 1000;
    }
}
