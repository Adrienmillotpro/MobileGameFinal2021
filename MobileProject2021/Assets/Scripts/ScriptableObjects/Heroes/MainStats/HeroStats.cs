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
        this.heroDamage = hero.HeroDamage;
        this.heroAttackRate = hero.HeroAttackRate;
        this.heroElementalReactionMultiplier = hero.HeroElementalReactionMultiplier;
        this.heroCritRate = hero.HeroCritRate;
        this.heroCritDamage = hero.HeroCritDamage;
        this.heroAffinityMultiplier = hero.HeroAffinityMultiplier;
        this.herocurrencyMultiplier = hero.HeroCurrencyMultiplier;
    }
}
