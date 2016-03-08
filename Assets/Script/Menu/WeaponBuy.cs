using UnityEngine;
using System.Collections.Generic;
using System;

public class WeaponBuy : Buy
{
    public Weapon weapon;

    public override void SetActualItem(BuyableItem item)
    {
        SaveLoad.data.actualWeapon = (Weapon)item;
    }

    protected override BuyableItem actualItem()
    {
        return SaveLoad.data.actualWeapon;
    }

    public override BuyableItem itemToBuy()
    {
        return weapon;
    }

    protected override ICollection<BuyableItem> unlockedItemList()
    {
        return (ICollection<BuyableItem>)SaveLoad.data.unlockedWeapons;
    }
}
