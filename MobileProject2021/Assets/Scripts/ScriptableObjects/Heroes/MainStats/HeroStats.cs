using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    [SerializeField] private SO_Hero hero;

    [HideInInspector] public float heroDamage;
    [HideInInspector] public float heroAttackRate;
    [HideInInspector] public float heroElementalReactionMultiplier;
    [HideInInspector] public float heroCritRate;
    [HideInInspector] public float heroCritDamage;
    [HideInInspector] public float heroAffinityMultiplier;
    [HideInInspector] public float herocurrencyMultiplier;
    [HideInInspector] public ElementalTypes[] heroTypes;

    private void Awake()
    {
        // Subscribe to Upgrade events
        this.heroDamage = hero.HeroDamage;
        this.heroAttackRate = hero.HeroAttackRate;
        this.heroElementalReactionMultiplier = hero.HeroElementalReactionMultiplier;
        this.heroCritRate = hero.HeroCritRate;
        this.heroCritDamage = hero.HeroCritDamage;
        this.heroAffinityMultiplier = hero.HeroAffinityMultiplier;
        this.herocurrencyMultiplier = hero.HeroCurrencyMultiplier;
        this.heroTypes = hero.HeroTypes;
    }
    private void OnDestroy()
    {
        // Unsub to Upgrade events
    }

    private void Start()
    {
    }

}
