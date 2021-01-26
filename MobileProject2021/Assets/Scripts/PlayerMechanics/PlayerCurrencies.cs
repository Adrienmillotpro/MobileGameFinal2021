using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencies : MonoBehaviour
{
    public static event Action<OnEarnCurrencyEventArgs> OnEarnCurrency;
    private OnEarnCurrencyEventArgs onEarnCurrencyArgs;

    private float currencyBase;
    private float currencyPremium;
    private float currencyFire;
    private float currencyThunder;
    private float currencyWater;
    private float currencyAir;

    private void Awake()
    {
        EnemyManager.OnDealDamage += OnDealDamageEarnCurrency;
        GeneralUpgrade.OnUpgrade += OnUpgradeUpdateCurrency;
    }

    private void OnDisable()
    {
        EnemyManager.OnDealDamage -= OnDealDamageEarnCurrency;
        GeneralUpgrade.OnUpgrade -= OnUpgradeUpdateCurrency;
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

    private void OnDealDamageEarnCurrency(OnDamageEventArgs damageArgs)
    {
        onEarnCurrencyArgs.currencyAmount = damageArgs.enemyLevel;
        currencyBase += damageArgs.enemyLevel;
        if (damageArgs.bestElementalReaction == 2)
        {
            switch (damageArgs.bestHeroElement)
            {
                case ElementalTypes.Air:
                    currencyAir += damageArgs.enemyLevel;
                    break;
                case ElementalTypes.Fire:
                    currencyFire += damageArgs.enemyLevel;
                    break;
                case ElementalTypes.Thunder:
                    currencyThunder += damageArgs.enemyLevel;
                    break;
                case ElementalTypes.Water:
                    currencyWater += damageArgs.enemyLevel;
                    break;
            }
        }
    }
}
