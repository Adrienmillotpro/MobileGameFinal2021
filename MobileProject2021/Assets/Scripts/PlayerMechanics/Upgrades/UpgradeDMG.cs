using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDMG : GeneralUpgrade
{
    [SerializeField] private PlayerCurrencies playerCurrencies;
    [SerializeField] private HeroManager heroManager;
    [SerializeField]
    public static event Action<OnUpgradeEventArgs> OnUpgradeDMG;
    private OnUpgradeEventArgs onUpgradeArgs;
    [SerializeField] private Button upgradeDmgButton;

    private void Start()
    {
        this.upgradeLevel = 1;
        this.upgradeCost = 150;
        this.upgradeEffect = 20;
    }
    private void Update()
    {
        if (this.upgradeCost < playerCurrencies.CurrencyBase)
        {
            upgradeDmgButton.interactable = true;
        }
        else
        {
            upgradeDmgButton.interactable = false;
        }
    }

    public void UpgradeDamage() // Assign this to OnClick event of Button
    {
        UpdateArgs();
        OnUpgradeDMG?.Invoke(onUpgradeArgs);
        UpdateUpgradeSettings();
    }
    private void UpdateUpgradeSettings() // Increase cost & effect
    {
        this.upgradeLevel++;
        this.upgradeCost += this.upgradeLevel * this.upgradeCostMultiplier;
        this.upgradeEffect += this.upgradeLevel * this.upgradeEffectMultiplier;
    }
    private void UpdateArgs() // Update arguments passed in event
    {
        onUpgradeArgs.currencyBase = this.upgradeCost;
        onUpgradeArgs.upgradeEffect = this.upgradeEffect;
    }
}
