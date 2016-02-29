﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkinSetter : MonoBehaviour {

    private Image backgroundColor;
    private SkinBuy skinBuy;
    public Button useButton;

    void Start()
    {
        backgroundColor = gameObject.GetComponent<Image>();
        skinBuy = gameObject.GetComponent<SkinBuy>();
        
        if (Skin().id != SaveLoad.data.actualSkin.id)
        {
            backgroundColor.enabled = false;
        }

        ActivateUseButton();
    }

    public void ActivateUseButton()
    {
        if (!skinBuy.HidePanelIsActive())
        {
            useButton.gameObject.SetActive(true);
        }
    }

    public void UseSkin()
    {
        SkinSetter[] skins = GameObject.FindObjectsOfType<SkinSetter>();
        foreach(SkinSetter skinSetter in skins)
        {
            skinSetter.backgroundColor.enabled = false;
        }

        backgroundColor.enabled = true;
        SaveLoad.data.actualSkin = Skin();
    }

    private Skin Skin()
    {
        return skinBuy.skin;
    }
}