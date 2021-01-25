using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVisuals : MonoBehaviour
{
    [HideInInspector] public SO_Boss soBoss;
    //[HideInInspector] public Animator bossAnimator;
    [HideInInspector] public SpriteRenderer bossRenderer;

    private void Awake()
    {
        EnemyManager.OnDealDamage += OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn += OnSpawnUpdateHealth;
    }

    private void OnDestroy()
    {
        EnemyManager.OnDealDamage -= OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn -= OnSpawnUpdateHealth;
    }

    private void OnSpawnUpdateHealth(object sender, OnSpawnEventArgs spawnArgs)
    {
        // Stuff
    }

    private void OnDealDamageReceiveDamage(object sender, OnDamageEventArgs damageArgs)
    {
        // Stuff
    }
}
