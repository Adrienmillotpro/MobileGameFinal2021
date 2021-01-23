using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossStats : MonoBehaviour
{
    [HideInInspector] public float bossHealth;
    [HideInInspector] public float bossTimer;
    [HideInInspector] public ElementalTypes[] bossTypes;
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

        for (int i = 0; i < this.bossTypes.Length; i++)
        {
            for (int j = 0; j < damageArgs.damageTypes.Length; j++)
            {
                float newElementalReaction = TypeChart.DefineElementalReaction(damageArgs.damageTypes[j], bossTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                }
            }
        }
        Debug.Log(this.name + bestElementalReaction);
        this.bossHealth -= damageArgs.damage * bestElementalReaction;

        if (bestElementalReaction == 2f)
        {
            this.elementalDamageReceived += damageArgs.damage * bestElementalReaction;
        }

        if (this.bossHealth <= 0)
        {
            Destroy(this);
        }

        //Debug.Log(this.name + enemyHealth);
    }
}
