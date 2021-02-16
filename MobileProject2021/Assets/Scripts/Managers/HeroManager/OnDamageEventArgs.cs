using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageEventArgs : EventArgs
{
    public ElementalTypes[] damageTypes;
    public float enemyLevel;
    public float enemyMaxHealth;
    public float damage;
    public float bestElementalReaction;
    public ElementalTypes bestHeroElement;
    public ElementalTypes weakEnemyElement;

    public float CurrencyOnDamage()
    {
        float currencyOnDamage;
        currencyOnDamage = damage / enemyMaxHealth * 100 * enemyLevel * 0.008f;
        Debug.Log(currencyOnDamage);
        return currencyOnDamage;
    }
}
