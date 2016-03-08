using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSetter : MonoBehaviour {

    private Image backgroundColor;
    private Buy buy;

    void Start()
    {
        backgroundColor = gameObject.GetComponent<Image>();
        buy = gameObject.GetComponent<Buy>();
        
        if (ItemToBuy().id != SaveLoad.data.actualSkin.id)
        {
            backgroundColor.enabled = false;
        }
    }
    

    public void UseItem()
    {
        ItemSetter[] skins = GameObject.FindObjectsOfType<ItemSetter>();
        foreach(ItemSetter itemSetter in skins)
        {
            itemSetter.backgroundColor.enabled = false;
        }

        backgroundColor.enabled = true;
        buy.SetActualItem(ItemToBuy());
        SaveLoad.Save();
    }

    private BuyableItem ItemToBuy()
    {
        return buy.ItemToBuy();
    }
}
