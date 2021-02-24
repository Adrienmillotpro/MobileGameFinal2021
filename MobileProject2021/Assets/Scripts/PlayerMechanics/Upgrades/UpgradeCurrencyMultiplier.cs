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
            upgradeCurrMultButton.interactable = true;
        }
        else
        {
            upgradeCurrMultButton.interactable = false;
        }

    }

    public void UpgradeCurrMult() // Assign this to OnClick event of Button
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
    }
    private void UpdateArgs() // Update arguments passed in event
    {
        onUpgradeArgs.currencyBase = this.currentUpgradeCost;
        Debug.Log(onUpgradeArgs.currencyBase);
        onUpgradeArgs.upgradeEffect = this.upgradeLevel * this.baseUpgradeEffect * this.upgradeEffectMultiplier;
        onUpgradeArgs.upgradeLevel = this.upgradeLevel;
        onUpgradeArgs.nextUpgradeEffect = (this.upgradeLevel +1) * this.baseUpgradeEffect * this.upgradeEffectMultiplier;
    }

}
