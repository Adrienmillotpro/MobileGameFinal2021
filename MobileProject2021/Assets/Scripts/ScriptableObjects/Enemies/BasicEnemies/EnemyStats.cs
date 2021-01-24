using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [HideInInspector] public SO_Enemy soEnemy;
    //private ElementalTypes[] enemyTypes;
    private float enemyHealth;
    private float elementalDamageReceived;

    public event EventHandler<OnKilledEventArgs> OnKilled;
    private OnKilledEventArgs onKilledArgs = new OnKilledEventArgs(0f);

    private void Awake()
    {
        EnemyManager.OnDealDamage += ReceiveDamage;
        EnemyManager.OnSpawn += OnSpawnUpdateHealth;
        Debug.Log("We got there" + this.soEnemy == null);
        this.enemyHealth = 0f;
        Debug.Log("Survived");
    }

    private void OnSpawnUpdateHealth(object sender, OnSpawnEventArgs spawnArgs)
    {
        this.enemyHealth = soEnemy.EnemyHealth;
    }

    private void OnDestroy()
    {
        Debug.Log("I'm being destroyed");
        EnemyManager.OnDealDamage -= ReceiveDamage;
        EnemyManager.OnSpawn -= OnSpawnUpdateHealth;
    }

    private void ReceiveDamage(object sender, OnDamageEventArgs damageArgs)
    {
        
        Debug.Log(this.name + damageArgs.bestElementalReaction);
        this.enemyHealth -= damageArgs.damage;

        if (damageArgs.bestElementalReaction == 2f)
        {
            this.elementalDamageReceived += damageArgs.damage;
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
