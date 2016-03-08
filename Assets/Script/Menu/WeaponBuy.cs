using UnityEngine;
using System.Collections.Generic;

public class WeaponBuy : Buy
{
    public Weapon weapon;

    public override void SetActualItem(BuyableItem item)
    {
        SaveLoad.data.actualWeapon = (Weapon)item;
    }

    protected override BuyableItem ActualItem()
    {
        return SaveLoad.data.actualWeapon;
    }

    public override BuyableItem ItemToBuy()
    {
        return weapon;
    }

    protected override ICollection<BuyableItem> UnlockedItemList()
    {
        return SaveLoad.data.unlockedWeapons;
    }
}
