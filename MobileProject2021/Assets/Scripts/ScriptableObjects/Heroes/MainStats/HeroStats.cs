using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    [SerializeField] private SO_Hero hero;

    private float heroDamage;
    private float heroAttackRate;
    private float heroElementalReactionMultiplier;
    private float heroCritRate;
    private float heroCritDamage;
    private float heroAffinityMultiplier;
    private float herocurrencyMultiplier;

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
