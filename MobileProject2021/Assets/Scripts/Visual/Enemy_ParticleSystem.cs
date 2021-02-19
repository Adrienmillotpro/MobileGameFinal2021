using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ParticleSystem : MonoBehaviour
{
    private void OnEnable()
    {
        EnemyManager.OnSpawn += OnSpawnInstantiateSmoke;
    }

    private void OnDisable()
    {
        EnemyManager.OnSpawn -= OnSpawnInstantiateSmoke;
    }

    private void OnSpawnInstantiateSmoke(OnSpawnEventArgs spawnArgs)
    {
        
    }
}
