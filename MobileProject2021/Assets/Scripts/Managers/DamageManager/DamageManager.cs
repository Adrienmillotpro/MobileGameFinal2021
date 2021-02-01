using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private McStats mcStats;
    [SerializeField] private HeroManager heroManager;
    [SerializeField] private EnemyManager enemyManager;

    // Events
    public static event Action<OnDamageEventArgs> OnDealDamage;
    private OnDamageEventArgs onDealDamageArgs = new OnDamageEventArgs();

    private event Action<OnDamageEventArgs> OnClick;
    private OnDamageEventArgs damageArgs = new OnDamageEventArgs();

    private void Awake()
    {
        TapMechanic.OnTap += OnTapDealDamage;
        OnClick += OnClickCalculateDamage;
    }
    private void OnDisable()
    {
        TapMechanic.OnTap -= OnTapDealDamage;
        OnClick -= OnClickCalculateDamage;
    }

    public void OnTapDealDamage(OnTapEventArgs tapArgs) // Pass Arguments to reduce enemy health
    {
        if (OnClick != null)
        {
            //Debug.Log("I received the Tap");
            this.damageArgs.damage = heroManager.CurrentStats.heroDamage + mcStats.damage;
            this.damageArgs.damageTypes = heroManager.CurrentStats.heroTypes;
            //Debug.Log("I'm sending this damage" + damageArgs.damage);
            OnClick?.Invoke(damageArgs);
        }
    }

    private void OnClickCalculateDamage(OnDamageEventArgs damageArgs)
    {
        //Debug.Log("I'm calculating damage");
        float bestElementalReaction = new float();
        ElementalTypes bestElementalType = new ElementalTypes();
        ElementalTypes weakElementalType = new ElementalTypes();

        for (int i = 0; i < this.enemyManager.CurrentSoEnemy.EnemyTypes.Length; i++)
        {
            for (int j = 0; j < damageArgs.damageTypes.Length; j++)
            {
                float newElementalReaction = TypeChart.DefineElementalReaction(damageArgs.damageTypes[j], enemyManager.CurrentSoEnemy.EnemyTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                    bestElementalType = damageArgs.damageTypes[j];
                    weakElementalType = enemyManager.CurrentSoEnemy.EnemyTypes[i];
                }
            }
        }
        onDealDamageArgs.enemyLevel = enemyManager.EnemyLevel;
        onDealDamageArgs.enemyMaxHealth = enemyManager.CurrentEnemyStats.EnemyMaxHealth;
        onDealDamageArgs.damageTypes = damageArgs.damageTypes;
        onDealDamageArgs.bestElementalReaction = bestElementalReaction;
        onDealDamageArgs.bestHeroElement = bestElementalType;
        onDealDamageArgs.weakEnemyElement = weakElementalType;
        onDealDamageArgs.damage = damageArgs.damage * bestElementalReaction;
        Debug.Log("DealDamage - damageArgs.damage " + onDealDamageArgs.damage);

         OnDealDamage?.Invoke(onDealDamageArgs);
    }

}
