using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencies : MonoBehaviour
{
    [SerializeField] private int currencyBase;
    [SerializeField] private int currencyPremium;
    [SerializeField] private int currencyFire;
    [SerializeField] private int currencyThunder;
    [SerializeField] private int currencyWater;
    [SerializeField] private int currencyAir;
    #region Getters
    public float CurrencyBase { get { return currencyBase; } }
    public float CurrencyPremium { get { return currencyPremium; } }
    public float CurrencyFire { get { return currencyFire; } }
    public float CurrencyWater { get { return currencyWater; } }
    public float CurrencyThunder { get { return currencyThunder; } }
    public float CurrencyAir { get { return currencyAir; } }
    #endregion

    public static event Action<OnUpdateCurrenciesEventArgs> OnUpdateCurrency;
    private OnUpdateCurrenciesEventArgs currenciesArgs;

    private void Awake()
    {
        DamageManager.OnDealDamage += OnDealDamageEarnCurrency;
        UpgradeDMG.OnUpgradeDMG += OnUpgradeUpdateCurrency;
    }
    private void OnDisable()
    {
        DamageManager.OnDealDamage -= OnDealDamageEarnCurrency;
        UpgradeDMG.OnUpgradeDMG -= OnUpgradeUpdateCurrency;
    }

    private void OnUpgradeUpdateCurrency(OnUpgradeEventArgs upgradeArgs)
    {
        currencyBase -= (int)upgradeArgs.currencyBase;
        currencyFire -= (int)upgradeArgs.currencyFire;
        currencyThunder -= (int)upgradeArgs.currencyThunder;
        currencyWater -= (int)upgradeArgs.currencyWater;
        currencyAir -= (int)upgradeArgs.currencyAir;
        currencyPremium -= (int)upgradeArgs.currencyPremium;


        OnUpdateCurrency?.Invoke(currenciesArgs);
    }
    private void OnDealDamageEarnCurrency(OnDamageEventArgs damageArgs) // This triggers when player deals damage to an enemy
    {
        currencyBase += (int)damageArgs.CurrencyOnDamage(); // Player earns Base Currency
        if (damageArgs.bestElementalReaction == 2)
        {
            switch (damageArgs.weakEnemyElement) // Check if player should earn Elemental Currency
            {
                case ElementalTypes.Air:
                    currencyAir += (int)damageArgs.CurrencyOnDamage();
                    break;
                case ElementalTypes.Fire:
                    currencyFire += (int)damageArgs.CurrencyOnDamage();
                    break;
                case ElementalTypes.Thunder:
                    currencyThunder += (int)damageArgs.CurrencyOnDamage();
                    break;
                case ElementalTypes.Water:
                    currencyWater += (int)damageArgs.CurrencyOnDamage();
                    break;
            }
        }
        UpdateCurrenciesArgs();
        OnUpdateCurrency?.Invoke(currenciesArgs);
    }

    private void UpdateCurrenciesArgs()
    {
        currenciesArgs.currentBase = this.currencyBase;
        currenciesArgs.currentPremium = this.currencyPremium;
        currenciesArgs.currentFire = this.currencyFire;
        currenciesArgs.currentAir = this.currencyAir;
        currenciesArgs.currentThunder = this.currencyThunder;
        currenciesArgs.currentWater = this.currencyWater;
    }
}
