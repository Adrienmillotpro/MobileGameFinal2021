using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    [SerializeField] private SO_Enemy enemy;
    private Animator enemyAnimator;
    private SpriteRenderer enemyRenderer;

    private void Start()
    {
        this.enemyRenderer = GetComponent<SpriteRenderer>();
        this.enemyAnimator = GetComponent<Animator>();

        // Update Prefab Info with SO Info
        this.enemyRenderer.sprite = enemy.EnemySprite;
        this.enemyAnimator = enemy.EnemyAnimator;
    }
}
