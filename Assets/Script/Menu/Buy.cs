using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class Buy : MonoBehaviour {

    public Button buyButton;
    public GameObject hidePanel;
    public Text buyButtonText;

    private ItemSetter itemSetter;

    protected abstract ICollection<BuyableItem> UnlockedItemList();
    public abstract BuyableItem ItemToBuy();
    protected abstract BuyableItem ActualItem();
    public abstract void SetActualItem(BuyableItem item);

    void Start()
    {
        buyButtonText.text = ItemToBuy().price + SceneLoader.VOL;
        itemSetter = gameObject.GetComponent<ItemSetter>();
    }

	void OnGUI() {
        buyButton.interactable = BuyIsEnabled();
        hidePanel.SetActive(HidePanelIsActive());
    }

    private bool BuyIsEnabled()
    {
        return SaveLoad.data.sumOfScores >= ItemToBuy().price;
    }

    public bool HidePanelIsActive()
    {
        foreach (BuyableItem tempItem in UnlockedItemList())
        {
            if (tempItem.id == ItemToBuy().id)
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
            UnlockedItemList().Add(ItemToBuy());
            SaveLoad.data.sumOfScores -= ItemToBuy().price;
            SaveLoad.Save();

            itemSetter.UseItem();
        }
    }
}
