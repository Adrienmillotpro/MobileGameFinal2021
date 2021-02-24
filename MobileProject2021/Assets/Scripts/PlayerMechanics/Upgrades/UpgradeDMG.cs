using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDMG : GeneralUpgrade
{
    [SerializeField] private Button upgradeDmgButton;
    

    public static event Action<OnUpgradeEventArgs> OnUpgradeDMG;
    private OnUpgradeEventArgs onUpgradeArgs = new OnUpgradeEventArgs();

    private void Awake()
    {
        PlayerCurrencies.OnUpdateCurrency += OnUpdateCurrencyUpdateButton;
    }

    private void OnDisable()
    {
        PlayerCurrencies.OnUpdateCurrency -= OnUpdateCurrencyUpdateButton;
    }

    private void Start()
    {
        this.currentUpgradeEffect = this.baseUpgradeEffect;
        this.currentUpgradeCost = this.baseUpgradeCost;
        this.upgradeLevel = 1;

    }

    private void OnUpdateCurrencyUpdateButton(OnUpdateCurrenciesEventArgs currenciesArgs)
    {
        if (this.currentUpgradeCost < currenciesArgs.currentBase)
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
        UpdateUpgradeSettings();
        OnUpgradeDMG?.Invoke(onUpgradeArgs);
    }
    private void UpdateUpgradeSettings() // Increase cost & effect
    {
        this.upgradeLevel++;
        this.currentUpgradeCost = this.baseUpgradeCost * Mathf.Pow(this.upgradeCostMultiplier, this.upgradeLevel);
        this.currentUpgradeEffect = this.upgradeLevel * this.baseUpgradeEffect * this.upgradeEffectMultiplier;
        Debug.Log(this.currentUpgradeEffect);
    }
    private void UpdateArgs() // Update arguments passed in event
    {
        
        onUpgradeArgs.currencyBase = this.baseUpgradeCost * Mathf.Pow(this.upgradeCostMultiplier, this.upgradeLevel);
        onUpgradeArgs.upgradeEffect = this.upgradeLevel * this.baseUpgradeEffect * this.upgradeEffectMultiplier;
        onUpgradeArgs.upgradeLevel = this.upgradeLevel;
        onUpgradeArgs.nextUpgradeEffect = (this.upgradeLevel +1) * this.baseUpgradeEffect * this.upgradeEffectMultiplier;

        Debug.Log("UpgradeEffect " + onUpgradeArgs.upgradeEffect);
        Debug.Log("NextUpgradeEffect " + onUpgradeArgs.nextUpgradeEffect);
    }
}
