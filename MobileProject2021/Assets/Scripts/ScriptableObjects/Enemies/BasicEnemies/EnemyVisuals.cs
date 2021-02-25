using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    [HideInInspector] public SO_Enemy soEnemy;

    private void Awake()
    {
        EnemyManager.OnSpawn += OnSpawnUpdateVisuals;
        DamageManager.OnDealDamage += OnDealDamageUpdateVisuals;
    }
    private void OnDestroy()
    {
        EnemyManager.OnSpawn -= OnSpawnUpdateVisuals;
        DamageManager.OnDealDamage -= OnDealDamageUpdateVisuals;
    }

    private void OnSpawnUpdateVisuals(OnSpawnEventArgs spawnArgs)
    {

    }
    private void OnDealDamageUpdateVisuals(OnDamageEventArgs damageArgs)
    {
        // stuff
    }
}
