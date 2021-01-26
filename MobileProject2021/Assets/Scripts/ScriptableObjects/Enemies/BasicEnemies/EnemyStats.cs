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

    public event Action<OnKilledEventArgs> OnEnemyKilled;
    private OnKilledEventArgs onKilledArgs = new OnKilledEventArgs();

    private void Awake()
    {
        EnemyManager.OnDealDamage += OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn += OnSpawnUpdateStats;
        this.enemyHealth = 0f;
    }
    private void OnDestroy()
    {
        EnemyManager.OnDealDamage -= OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn -= OnSpawnUpdateStats;
    }

    private void OnSpawnUpdateStats(OnSpawnEventArgs spawnArgs)
    {
        this.enemyHealth = spawnArgs.maxHealth;
    }
    private void OnDealDamageReceiveDamage(OnDamageEventArgs damageArgs)
    {
        this.enemyHealth -= damageArgs.damage;
        Debug.Log("This enemy has " + this.enemyHealth + " health left");

        if (damageArgs.bestElementalReaction == 2f)
        {
            this.elementalDamageReceived += damageArgs.damage;
        }

        if (this.enemyHealth <= 0)
        {
            OnEnemyKilled?.Invoke(onKilledArgs);
            Destroy(this.gameObject);
        }

    }
}
