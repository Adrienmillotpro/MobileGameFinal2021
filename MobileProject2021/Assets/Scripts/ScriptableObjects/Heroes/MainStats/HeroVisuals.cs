using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVisuals : MonoBehaviour
{
    [SerializeField] private SO_Hero SO_Hero;

    private Animator heroAnimator;
    private SpriteRenderer heroRenderer;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        //this.heroAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        DamageManager.OnDealDamage += OnDealDamageUpdateVisuals;
        animator.SetBool("EntranceAnimation", true);
        animator.SetBool("ExitAnimation", false);
        animator.SetBool("NoDamage", false);

    }
    private void OnDisable()
    {
        DamageManager.OnDealDamage -= OnDealDamageUpdateVisuals;
        animator.SetBool("ExitAnimation", true);
        animator.SetBool("EntranceAnimation", false);
        animator.SetBool("NoDamage", true);

    }

    private void Start()
    {
        // Update Prefab Info with SO Info
        //this.heroRenderer.sprite = SO_Hero.HeroSprite;
        //this.heroAnimator = SO_Hero.HeroAnimator;
    }

    private void OnDealDamageUpdateVisuals(OnDamageEventArgs damageArgs)
    {
        
        if (damageArgs.isAutoAttack && damageArgs.bestElementalReaction != 0 )
        {
            animator.SetBool("AutoAttack", true);
            


        }
        else if(damageArgs.isAutoAttack && damageArgs.bestElementalReaction == 0)
        {
            animator.SetBool("NoDamage", true);
            animator.SetBool("AutoAttack", false);
        }
       
    }
}
