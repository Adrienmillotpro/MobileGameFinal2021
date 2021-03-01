using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageEventArgs : EventArgs
{
    public ElementalTypes damageType;
    public float elementalMultiplier;
    public float currencyMultiplier;
    public float enemyLevel;
    public float enemyMaxHealth;
    public float damage;
    public float bestElementalReaction;
    public ElementalTypes bestHeroElement;
    public ElementalTypes weakEnemyElement;

    public bool isAutoAttack;

    public float CurrencyOnDamage()
    {
        float currencyOnDamage;
        if (damage >= enemyMaxHealth)
        {
            currencyOnDamage = 100 * enemyLevel * 0.008f;
        }
        else
        {
            currencyOnDamage = damage / enemyMaxHealth * 100 * enemyLevel * 0.008f;
        }

        //Debug.Log(currencyOnDamage);
        return currencyOnDamage;
    }

    public float ElementalCurrencyOnDamage()
    {
        float elementalCurrencyOnDamage;
        if (damage >= enemyMaxHealth)
        {
            elementalCurrencyOnDamage = 100;
        }
        else
        {
            elementalCurrencyOnDamage = damage / enemyMaxHealth * 100;
        }
        return elementalCurrencyOnDamage;
    }
}
