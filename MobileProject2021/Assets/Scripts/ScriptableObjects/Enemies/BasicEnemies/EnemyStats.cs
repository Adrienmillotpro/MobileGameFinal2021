using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private SO_Enemy SOenemy;
    [HideInInspector] public float enemyHealth;
    [HideInInspector] public float elementalDamageReceived;

    public event EventHandler<OnKilledEventArgs> OnKilled;
    private OnKilledEventArgs onKilledArgs;

    private void Awake()
    {
        DamageEvent.OnClick += ReceiveDamage;
    }

    private void OnDestroy()
    {
        DamageEvent.OnClick -= ReceiveDamage;
        OnKilled?.Invoke(this, onKilledArgs);
    }

    private void ReceiveDamage(object sender, OnDamageEventArgs damageArgs)
    {
        float bestElementalReaction = new float();

        for (int i = 0; i < SOenemy.EnemyTypes.Length; i++)
        {
            for (int j = 0; j < damageArgs.damageTypes.Length; j++)
            {
                float newElementalReaction = TypeChart.DefineElementalReaction(damageArgs.damageTypes[j], SOenemy.EnemyTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                }
            }
        }
        Debug.Log(this.name + bestElementalReaction);
        enemyHealth -= damageArgs.damage * bestElementalReaction;

        if (bestElementalReaction == 2f)
        {
            elementalDamageReceived += damageArgs.damage * bestElementalReaction;
        }

        if (enemyHealth <= 0)
        {
            Destroy(this);
        }

        //Debug.Log(this.name + enemyHealth);
    }
}
