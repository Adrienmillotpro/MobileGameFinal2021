using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencies : MonoBehaviour
{
    [SerializeField] private float currencyBase;
    [SerializeField] private float currencyPremium;
    [SerializeField] private float currencyElemental;
    #region Getters
    public float CurrencyBase { get { return currencyBase; } }
    public float CurrencyPremium { get { return currencyPremium; } }
    public float CurrencyElemental { get { return currencyElemental; } }

    #endregion

    public static event Action<OnUpdateCurrenciesEventArgs> OnUpdateCurrency;
    private OnUpdateCurrenciesEventArgs currenciesArgs = new OnUpdateCurrenciesEventArgs();

    private void Awake()
    {
        DamageManager.OnDealDamage += OnDealDamageEarnCurrency;
        UpgradeDMG.OnUpgradeDMG += OnUpgradeUpdateCurrency;
        UpgradeAttackRate.OnUpgradeAttackRate += OnUpgradeUpdateCurrency;
        UpgradeElementalMultiplier.OnUpgradeElemMult += OnUpgradeUpdateCurrency;
        UpgradeCurrencyMultiplier.OnUpgradeCurrMult += OnUpgradeUpdateCurrency;
    }
    private void OnDisable()
    {
        DamageManager.OnDealDamage -= OnDealDamageEarnCurrency;
        UpgradeDMG.OnUpgradeDMG -= OnUpgradeUpdateCurrency;
        UpgradeAttackRate.OnUpgradeAttackRate -= OnUpgradeUpdateCurrency;
        UpgradeElementalMultiplier.OnUpgradeElemMult -= OnUpgradeUpdateCurrency;
        UpgradeCurrencyMultiplier.OnUpgradeCurrMult -= OnUpgradeUpdateCurrency;
    }

    private void Start()
    {
        UpdateCurrenciesArgs();
        OnUpdateCurrency?.Invoke(currenciesArgs);
    }
    private void OnUpgradeUpdateCurrency(OnUpgradeEventArgs upgradeArgs)
    {
        currencyBase -= upgradeArgs.currencyBase;
        currencyElemental -= upgradeArgs.currencyElemental;
        currencyPremium -= upgradeArgs.currencyPremium;

        UpdateCurrenciesArgs();
        OnUpdateCurrency?.Invoke(currenciesArgs);
    }

    private void OnDealDamageEarnCurrency(OnDamageEventArgs damageArgs) // This triggers when player deals damage to an enemy
    {
        currencyBase += damageArgs.CurrencyOnDamage(); // Player earns Base Currency
        if (damageArgs.bestElementalReaction == 2)
        {
            currencyElemental += damageArgs.CurrencyOnDamage();
        }
        UpdateCurrenciesArgs();
        OnUpdateCurrency?.Invoke(currenciesArgs);
    }

    private void UpdateCurrenciesArgs()
    {
        currenciesArgs.currentBase = this.currencyBase;
        currenciesArgs.currentPremium = this.currencyPremium;
        currenciesArgs.currentElemental = this.currencyElemental;
    }

    public void CommunionUpdateCurrency(bool isPremium, float cost)
    {
        if (isPremium)
        {
            currencyPremium -= cost;
        }
        else
        {
            currencyElemental -= cost;
        }
    }
}
