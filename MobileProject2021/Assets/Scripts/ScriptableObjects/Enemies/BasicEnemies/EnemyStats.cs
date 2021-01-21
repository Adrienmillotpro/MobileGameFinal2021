using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private SO_Enemy enemy;
    [HideInInspector] public float enemyHealth;
    [HideInInspector] public float elementalDamageReceived;

    //private DamageEvent damageEvent;

    private void OnEnable()
    {
        DamageEvent.OnClick += ReceiveDamage;
    }

    private void OnDisable()
    {
        DamageEvent.OnClick -= ReceiveDamage;
    }

    private void Start()
    {
        this.enemyHealth = enemy.EnemyHealth;
    }

    private void ReceiveDamage(object sender, OnDamageEventArgs args)
    {
        float bestElementalReaction = new float();

        for (int i = 0; i < enemy.EnemyTypes.Length; i++)
        {
            for (int j = 0; j < args.damageTypes.Length; j++)
            {
                float newElementalReaction = TypeChart.DefineElementalReaction(args.damageTypes[j], enemy.EnemyTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                }
            }
        }
        Debug.Log(this.name + bestElementalReaction);
        enemyHealth -= args.damage * bestElementalReaction;

        if (bestElementalReaction == 2f)
        {
            elementalDamageReceived += args.damage * bestElementalReaction;
        }

        //Debug.Log(this.name + enemyHealth);
    }
}
