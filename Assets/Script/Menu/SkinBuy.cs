using UnityEngine;
using System.Collections.Generic;

public class SkinBuy : Buy
{
    public Skin skin;

    public override void SetActualItem(BuyableItem item)
    {
        SaveLoad.data.actualSkin = (Skin)item;
    }

    protected override BuyableItem actualItem()
    {
        return SaveLoad.data.actualSkin;
    }

    public override BuyableItem itemToBuy()
    {
        return skin;
    }

    protected override ICollection<BuyableItem> unlockedItemList()
    {
        return (ICollection<BuyableItem>)SaveLoad.data.unlockedSkins;
    }
}
