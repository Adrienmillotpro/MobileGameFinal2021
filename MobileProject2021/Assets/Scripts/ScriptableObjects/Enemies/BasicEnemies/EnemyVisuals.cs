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
        this.enemyRenderer = GetComponent<SpriteRenderer>();
        //this.enemyAnimator = GetComponent<Animator>();

        this.enemyRenderer.sprite = soEnemy.EnemySprite;
        //this.enemyAnimator = soEnemy.EnemyAnimator;
    }
}
