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
        DamageManager.OnDealDamage += OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn += OnSpawnUpdateHealth;
    }
    private void OnDestroy()
    {
        DamageManager.OnDealDamage -= OnDealDamageReceiveDamage;
        EnemyManager.OnSpawn -= OnSpawnUpdateHealth;
    }

    private void OnSpawnUpdateHealth(OnSpawnEventArgs spawnArgs)
    {
        // Stuff
    }
    private void OnDealDamageReceiveDamage(OnDamageEventArgs damageArgs)
    {
        // Stuff
    }
}
