using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDMG : GeneralUpgrade
{
    [SerializeField] private Button upgradeDmgButton;

    private PlayerCurrencies playerCurrencies;
    
    public static event Action<OnUpgradeEventArgs> OnUpgradeDMG;
    private OnUpgradeEventArgs onUpgradeArgs = new OnUpgradeEventArgs();

    private void Awake()
    {
        playerCurrencies = FindObjectOfType<PlayerCurrencies>();
    }

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
        this.upgradeCost += this.upgradeCost * this.upgradeLevel * this.upgradeCostMultiplier;
        this.upgradeEffect += this.upgradeLevel * this.upgradeEffectMultiplier;
    }
    private void UpdateArgs() // Update arguments passed in event
    {
        onUpgradeArgs.currencyBase = this.upgradeCost;
        onUpgradeArgs.upgradeEffect = this.upgradeEffect;
        onUpgradeArgs.upgradeLevel = this.upgradeLevel;
        onUpgradeArgs.nextUpgradeEffect = this.upgradeEffect + this.upgradeLevel * this.upgradeEffectMultiplier;
    }
}
