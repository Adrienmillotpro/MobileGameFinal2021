using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVisuals : MonoBehaviour
{
    [SerializeField] private SO_Boss boss;
    private Animator bossAnimator;
    private SpriteRenderer bossRenderer;

    private void Start()
    {
        this.bossRenderer = GetComponent<SpriteRenderer>();
        this.bossAnimator = GetComponent<Animator>();

        // Update Prefab Info with SO Info
        this.bossRenderer.sprite = boss.BossSprite;
        this.bossAnimator = boss.BossAnimator;
    }
}
