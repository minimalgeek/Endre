using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponBuy : MonoBehaviour
{

    public Weapon weapon;

    public Button buyButton;
    public GameObject hidePanel;
    public Text buyButtonText;

    void Start()
    {
        buyButtonText.text = weapon.price + "% vol";
    }

    void OnGUI()
    {
        buyButton.interactable = WeaponBuyIsEnabled();
        hidePanel.SetActive(HidePanelIsActive());
    }

    private bool WeaponBuyIsEnabled()
    {
        return SaveLoad.data.sumOfScores >= weapon.price && SaveLoad.data.actualWeapon.id + 1 == weapon.id;
    }

    private bool HidePanelIsActive()
    {
        return weapon.id > SaveLoad.data.actualWeapon.id;
    }

    public void BuyWeapon()
    {
        if (WeaponBuyIsEnabled())
        {
            SaveLoad.data.actualWeapon = weapon;
            SaveLoad.data.sumOfScores -= weapon.price;
            SaveLoad.Save();
        }
    }
}
