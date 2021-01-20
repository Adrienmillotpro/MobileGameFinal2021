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

    private void Start()
    {
        this.heroDamage = hero.heroDamage;
        this.heroAttackRate = hero.heroAttackRate;
        this.heroElementalReactionMultiplier = hero.heroElementalReactionMultiplier;
        this.heroCritRate = hero.heroCritRate;
        this.heroCritDamage = hero.heroCritDamage;
        this.heroAffinityMultiplier = hero.heroAffinityMultiplier;
        this.herocurrencyMultiplier = hero.currencyMultiplier;
    }
}
