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
    }

    private void OnDestroy()
    {
        EnemyManager.OnSpawn -= OnSpawnUpdateVisuals;
    }
    private void OnSpawnUpdateVisuals(object sender, OnSpawnEventArgs spawnArgs)
    {
        this.enemyRenderer.sprite = soEnemy.EnemySprite;
    }
}
