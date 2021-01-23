using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    [HideInInspector] public Animator enemyAnimator;
    [HideInInspector] public SpriteRenderer enemyRenderer;

    private void Awake()
    {
        this.enemyRenderer = GetComponent<SpriteRenderer>();
        this.enemyAnimator = GetComponent<Animator>();
    }
}
