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
        buyButtonText.text = skin.price + SceneLoader.VOL;
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

    public bool HidePanelIsActive()
    {
        foreach (Skin tempSkin in SaveLoad.data.unlockedSkins)
        {
            if (tempSkin.id == skin.id)
            {
                return false;
            }
        }
        return true;
    }

    public void BuySkin()
    {
        if (SkinBuyIsEnabled())
        {
            SaveLoad.data.unlockedSkins.Add(skin);
            SaveLoad.data.sumOfScores -= skin.price;
            SaveLoad.Save();

            skinSetter.UseSkin();
        }
    }
}
