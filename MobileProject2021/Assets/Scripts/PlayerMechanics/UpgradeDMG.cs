using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDMG : GeneralUpgrade
{
    private OnUpgradeEventArgs onUpgradeArgs;
    [SerializeField] private Button upgradeDmgButton;

    private void Awake()
    {
        PlayerCurrencies.OnEarnCurrency += OnEarnCurrencyUpdateUpgradeStatus;
    }

    private void OnDisable()
    {
        PlayerCurrencies.OnEarnCurrency -= OnEarnCurrencyUpdateUpgradeStatus;
    }

    private void Start()
    {
        this.upgradeCost = 150;
        this.upgradeEffect = 20;
    }

    public void Upgrade()
    {
        UpdateArgs();
        OnUpgrade?.Invoke(onUpgradeArgs);
    }

    private void OnEarnCurrencyUpdateUpgradeStatus(OnEarnCurrencyEventArgs currencyArgs)
    {
        if (this.upgradeCost < currencyArgs.currencyBase)
        {
            upgradeDmgButton.interactable = true;
        }
        else
        {
            upgradeDmgButton.interactable = false;
        }
    }

    private void UpdateArgs()
    {
        onUpgradeArgs.currencyBase = this.upgradeCost;
    }
}
