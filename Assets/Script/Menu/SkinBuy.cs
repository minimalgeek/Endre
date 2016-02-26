using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkinBuy : MonoBehaviour {

    public Skin skin;

    public Button buyButton;
    public GameObject hidePanel;
    public Text buyButtonText;

    private SkinSetter skinSetter;

    void Start()
    {
        buyButtonText.text = skin.price + "% vol";
        skinSetter = gameObject.GetComponent<SkinSetter>();
    }

	void OnGUI() {
        buyButton.interactable = SkinBuyIsEnabled();
        hidePanel.SetActive(HidePanelIsActive());
    }

    private bool SkinBuyIsEnabled()
    {
        return SaveLoad.data.sumOfScores >= skin.price && SaveLoad.data.actualSkin.id + 1 == skin.id;
    }

    private bool HidePanelIsActive()
    {
        return skin.id > SaveLoad.data.actualSkin.id;
    }

    public void BuySkin()
    {
        if (SkinBuyIsEnabled())
        {
            skinSetter.UseSkin();
            SaveLoad.data.sumOfScores -= skin.price;
            SaveLoad.Save();
        }
    }
}
