using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCurrencyMultiplier : GeneralUpgrade
{
    [SerializeField] private Button upgradeCurrMultButton;

    public static event Action<OnUpgradeEventArgs> OnUpgradeCurrMult;
    private OnUpgradeEventArgs onUpgradeArgs = new OnUpgradeEventArgs();

    private void Awake()
    {
        PlayerCurrencies.OnUpdateCurrency += OnUpdateCurrencyUpdateButton;
    }

    private void OnDisable()
    {
        PlayerCurrencies.OnUpdateCurrency -= OnUpdateCurrencyUpdateButton;
    }

    private void OnUpdateCurrencyUpdateButton(OnUpdateCurrenciesEventArgs currenciesArgs)
    {
        if (this.currentUpgradeCost < currenciesArgs.currentBase)
        {
            upgradeCurrMultButton.interactable = true;
        }
        else
        {
            upgradeCurrMultButton.interactable = false;
        }
    }

    public void UpgradeDamage() // Assign this to OnClick event of Button
    {
        UpdateArgs();
        UpdateUpgradeSettings();
        OnUpgradeCurrMult?.Invoke(onUpgradeArgs);
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
        onUpgradeArgs.currencyBase = this.currentUpgradeCost;
        onUpgradeArgs.upgradeEffect = this.currentUpgradeEffect;
        onUpgradeArgs.upgradeLevel = this.upgradeLevel;
        onUpgradeArgs.nextUpgradeEffect = this.currentUpgradeEffect + this.upgradeLevel * this.upgradeEffectMultiplier;
    }
}
