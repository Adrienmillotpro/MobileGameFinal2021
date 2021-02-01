using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVisuals : MonoBehaviour
{
    [SerializeField] private SO_Hero SO_Hero;

    private Animator heroAnimator;
    private SpriteRenderer heroRenderer;

    private void Awake()
    {
        this.heroRenderer = GetComponent<SpriteRenderer>();
        this.heroAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        this.heroRenderer.enabled = true;
        DamageManager.OnDealDamage += OnDealDamageUpdateVisuals;
    }
    private void OnDisable()
    {
        this.heroRenderer.enabled = false;
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

    }
}
