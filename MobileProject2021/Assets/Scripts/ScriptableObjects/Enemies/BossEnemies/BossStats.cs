using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossStats : MonoBehaviour
{
    [HideInInspector] public SO_Boss soBoss;
    [HideInInspector] public float bossHealth;
    [HideInInspector] public float bossTimer;
    [HideInInspector] public ElementalTypes[] bossTypes;
    [HideInInspector] public float elementalDamageReceived;

    public event EventHandler<OnKilledEventArgs> OnBossKilled;
    private OnKilledEventArgs onKilledArgs;

    private void Awake()
    {
        EnemyManager.OnDealDamage += OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn += OnSpawnUpdateStats;
    }
    private void OnDestroy()
    {
        EnemyManager.OnDealDamage -= OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn -= OnSpawnUpdateStats;
    }

    private void OnSpawnUpdateStats(OnSpawnEventArgs spawnArgs)
    {
        this.bossHealth = spawnArgs.maxHealth;
        this.bossTimer = spawnArgs.bossTimer;
        StartCoroutine(BossTimer(this.bossTimer));
    }
    private void OnDealDamageReceiveDamage(OnDamageEventArgs damageArgs)
    {
        this.bossHealth -= damageArgs.damage;

        if (damageArgs.bestElementalReaction == 2f)
        {
            this.elementalDamageReceived += damageArgs.damage;
        }

        if (this.bossHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnBossKilled?.Invoke(this, onKilledArgs);
        Destroy(this.gameObject);
    }

    private IEnumerator BossTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        Die();
    }
}
