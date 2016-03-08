using UnityEngine;
using System.Collections.Generic;

public class SkinBuy : Buy
{
    public Skin skin;

    public override void SetActualItem(BuyableItem item)
    {
        SaveLoad.data.actualSkin = (Skin)item;
    }

    protected override BuyableItem ActualItem()
    {
        return SaveLoad.data.actualSkin;
    }

    public override BuyableItem ItemToBuy()
    {
        return skin;
    }

    protected override ICollection<BuyableItem> UnlockedItemList()
    {
        return SaveLoad.data.unlockedSkins;
    }
}
