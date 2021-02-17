using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVisuals : MonoBehaviour
{
    [SerializeField] private SO_Hero SO_Hero;

    private Animator heroAnimator;
    private SpriteRenderer heroRenderer;
    [SerializeField] private Animation[] animations;

    private void Awake()
    {
        //this.heroAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        DamageManager.OnDealDamage += OnDealDamageUpdateVisuals;
        animations[0].Play();
    }
    private void OnDisable()
    {
        DamageManager.OnDealDamage -= OnDealDamageUpdateVisuals;
    }

    private void Start()
    {
        // Update Prefab Info with SO Info
        //this.heroRenderer.sprite = SO_Hero.HeroSprite;
        //this.heroAnimator = SO_Hero.HeroAnimator;
    }

    private void OnDealDamageUpdateVisuals(OnDamageEventArgs damageArgs)
    {
        if (damageArgs.bestElementalReaction == 2)
        {
            // do animation for elemental reaction
        }
        else if (damageArgs.bestElementalReaction == 0)
        {
            // do other stuff
        }

        // 
    }
}
