using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    [SerializeField] private SO_Hero hero;

    [HideInInspector] public float heroDamage;
    [HideInInspector] public float heroAttackRate;
    [HideInInspector] public float heroElementalReactionMultiplier;
    [HideInInspector] public float herocurrencyMultiplier;
    [HideInInspector] public ElementalTypes[] heroTypes;

    private int heroLevel;
    private void Awake()
    {
        // Subscribe to Upgrade events
    }
    private void OnDisable()
    {
        // Unsub to Upgrade events
    }

    private void Start()
    {
        this.heroDamage = hero.HeroDamage;
        this.heroAttackRate = hero.HeroAttackRate;
        this.heroElementalReactionMultiplier = hero.HeroElementalReactionMultiplier;
        this.herocurrencyMultiplier = hero.HeroCurrencyMultiplier;
        this.heroTypes = hero.HeroTypes;
    }

}
