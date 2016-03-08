using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class Buy : MonoBehaviour {

    public Button buyButton;
    public GameObject hidePanel;
    public Text buyButtonText;

    private ItemSetter itemSetter;

    protected abstract ICollection<BuyableItem> unlockedItemList();
    public abstract BuyableItem itemToBuy();
    protected abstract BuyableItem actualItem();
    public abstract void SetActualItem(BuyableItem item);

    void Start()
    {
        buyButtonText.text = itemToBuy().price + SceneLoader.VOL;
        itemSetter = gameObject.GetComponent<ItemSetter>();
    }

	void OnGUI() {
        buyButton.interactable = BuyIsEnabled();
        hidePanel.SetActive(HidePanelIsActive());
    }

    private bool BuyIsEnabled()
    {
        return SaveLoad.data.sumOfScores >= itemToBuy().price && actualItem().id + 1 == itemToBuy().id;
    }

    public bool HidePanelIsActive()
    {
        foreach (BuyableItem tempItem in unlockedItemList())
        {
            if (tempItem.id == itemToBuy().id)
            {
                return false;
            }
        }
        return true;
    }

    public void BuyItem()
    {
        if (BuyIsEnabled())
        {
            unlockedItemList().Add(itemToBuy());
            SaveLoad.data.sumOfScores -= itemToBuy().price;
            SaveLoad.Save();

            itemSetter.UseItem();
        }
    }
}
