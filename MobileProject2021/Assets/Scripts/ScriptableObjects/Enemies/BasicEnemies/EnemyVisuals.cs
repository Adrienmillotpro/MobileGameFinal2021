using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    [HideInInspector] public SO_Enemy soEnemy;
    //[SerializeField] private Animator enemyAnimator;
    [SerializeField] private SpriteRenderer enemyRenderer;

    private void Awake()
    {
        EnemyManager.OnSpawn += OnSpawnUpdateVisuals;
        EnemyManager.OnDealDamage += OnDealDamageUpdateVisuals;
    }

    private void OnDestroy()
    {
        EnemyManager.OnSpawn -= OnSpawnUpdateVisuals;
        EnemyManager.OnDealDamage -= OnDealDamageUpdateVisuals;
    }
    private void OnSpawnUpdateVisuals(OnSpawnEventArgs spawnArgs)
    {
        this.enemyRenderer.sprite = soEnemy.EnemySprite;
    }

    private void OnDealDamageUpdateVisuals(OnDamageEventArgs damageArgs)
    {
        // stuff
    }
}
