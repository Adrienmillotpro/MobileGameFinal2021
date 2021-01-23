using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [HideInInspector] public SO_Enemy soEnemy;
    private ElementalTypes[] enemyTypes;
    private float enemyHealth;
    private float elementalDamageReceived;

    public event EventHandler<OnKilledEventArgs> OnKilled;
    private OnKilledEventArgs onKilledArgs;

    private void Awake()
    {
        DamageEvent.OnClick += ReceiveDamage;
        this.enemyHealth = soEnemy.EnemyHealth;
        this.enemyTypes = soEnemy.EnemyTypes;
    }

    private void OnDestroy()
    {
        Debug.Log("I'm being destroyed");
        DamageEvent.OnClick -= ReceiveDamage;
    }

    private void ReceiveDamage(object sender, OnDamageEventArgs damageArgs)
    {
        float bestElementalReaction = new float();

        for (int i = 0; i < this.enemyTypes.Length; i++)
        {
            for (int j = 0; j < damageArgs.damageTypes.Length; j++)
            {
                float newElementalReaction = TypeChart.DefineElementalReaction(damageArgs.damageTypes[j], enemyTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                }
            }
        }
        Debug.Log(this.name + bestElementalReaction);
        this.enemyHealth -= damageArgs.damage * bestElementalReaction;

        if (bestElementalReaction == 2f)
        {
            this.elementalDamageReceived += damageArgs.damage * bestElementalReaction;
        }

        if (this.enemyHealth <= 0)
        {
            Debug.Log("I'm dead");
            OnKilled?.Invoke(this, onKilledArgs);
            Destroy(this.gameObject);
        }

        Debug.Log(this.enemyHealth);

    }
}
