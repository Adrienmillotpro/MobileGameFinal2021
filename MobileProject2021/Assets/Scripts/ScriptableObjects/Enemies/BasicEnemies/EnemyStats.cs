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

    public event EventHandler<OnKilledEventArgs> OnEnemyKilled;
    private OnKilledEventArgs onKilledArgs = new OnKilledEventArgs();

    private void Awake()
    {
        EnemyManager.OnDealDamage += OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn += OnSpawnUpdateHealth;
        this.enemyHealth = 0f;
    }

    private void OnDestroy()
    {
        EnemyManager.OnDealDamage -= OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn -= OnSpawnUpdateHealth;
    }
    private void OnSpawnUpdateHealth(object sender, OnSpawnEventArgs spawnArgs)
    {
        this.enemyHealth = soEnemy.EnemyHealth;
    }

    private void OnDealDamageReceiveDamage(object sender, OnDamageEventArgs damageArgs)
    {
        this.enemyHealth -= damageArgs.damage;

        if (damageArgs.bestElementalReaction == 2f)
        {
            this.elementalDamageReceived += damageArgs.damage;
        }

        if (this.enemyHealth <= 0)
        {
            OnEnemyKilled?.Invoke(this, onKilledArgs);
            Destroy(this.gameObject);
        }

    }
}
