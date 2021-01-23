using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVisuals : MonoBehaviour
{
    //[HideInInspector] public Animator bossAnimator;
    [HideInInspector] public SpriteRenderer bossRenderer;

    private void Awake()
    {
        this.bossRenderer = GetComponent<SpriteRenderer>();
        //this.bossAnimator = GetComponent<Animator>();
    }
}
