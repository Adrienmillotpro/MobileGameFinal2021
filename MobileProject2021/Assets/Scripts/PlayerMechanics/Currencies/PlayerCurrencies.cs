using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencies : MonoBehaviour
{
    [SerializeField] private float currencyBase;
    [SerializeField] private float currencyPremium;
    [SerializeField] private float currencyFire;
    [SerializeField] private float currencyThunder;
    [SerializeField] private float currencyWater;
    [SerializeField] private float currencyAir;
    #region Getters
    public float CurrencyBase { get { return currencyBase; } }
    public float CurrencyPremium { get { return currencyPremium; } }
    public float CurrencyFire { get { return currencyFire; } }
    public float CurrencyWater { get { return currencyWater; } }
    public float CurrencyThunder { get { return currencyThunder; } }
    public float CurrencyAir { get { return currencyAir; } }
    #endregion

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
        currencyBase -= upgradeArgs.currencyBase;
        currencyFire -= upgradeArgs.currencyFire;
        currencyThunder -= upgradeArgs.currencyThunder;
        currencyWater -= upgradeArgs.currencyWater;
        currencyAir -= upgradeArgs.currencyAir;
        currencyPremium -= upgradeArgs.currencyPremium;
    }
    private void OnDealDamageEarnCurrency(OnDamageEventArgs damageArgs) // This triggers when player deals damage to an enemy
    {
        currencyBase += damageArgs.CurrencyOnDamage(); // Player earns Base Currency
        if (damageArgs.bestElementalReaction == 2)
        {
            switch (damageArgs.weakEnemyElement) // Check if player should earn Elemental Currency
            {
                case ElementalTypes.Air:
                    currencyAir += damageArgs.CurrencyOnDamage();
                    break;
                case ElementalTypes.Fire:
                    currencyFire += damageArgs.CurrencyOnDamage();
                    break;
                case ElementalTypes.Thunder:
                    currencyThunder += damageArgs.CurrencyOnDamage();
                    break;
                case ElementalTypes.Water:
                    currencyWater += damageArgs.CurrencyOnDamage();
                    break;
            }
        }
    }
}
