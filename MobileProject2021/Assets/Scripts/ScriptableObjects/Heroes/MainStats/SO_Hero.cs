using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Heroes", menuName = "Hero")]

public class SO_Hero : ScriptableObject
{
    [Header ("Hero Visuals")]
    [SerializeField] private Sprite heroSprite;
    [SerializeField] private Animator heroAnimator;
    #region Getters
    public Sprite HeroSprite { get { return heroSprite; } }
    public Animator HeroAnimator { get { return heroAnimator; } }
    #endregion

    [Header("Hero Stats")]
    [SerializeField] private float heroDamage;
    [SerializeField] private float heroAttackRate;
    [SerializeField] private float heroElementalReactionMultiplier;
    [SerializeField] private float heroCritRate;
    [SerializeField] private float heroCritDamage;
    [SerializeField] private float heroAffinityMultiplier;
    [SerializeField] private float heroCurrencyMultiplier;
    #region Getters
    public float HeroDamage { get { return heroDamage; } }
    public float HeroAttackRate { get { return heroAttackRate; } }
    public float HeroElementalReactionMultiplier { get { return heroElementalReactionMultiplier; } }
    public float HeroCritRate { get { return heroCritRate; } }
    public float HeroCritDamage { get { return heroCritDamage; } }
    public float HeroAffinityMultiplier { get { return heroAffinityMultiplier; } }
    public float HeroCurrencyMultiplier { get { return heroCurrencyMultiplier; } }
    #endregion

    [SerializeField] private ElementalTypes[] heroTypes;
    #region Getters
    public ElementalTypes[] HeroTypes { get { return heroTypes; } }
    #endregion

    [Header("Hero Perks")]
    [SerializeField] private SO_HeroPassivePerk passivePerk;
    [SerializeField] private SO_HeroActivePerk activePerk;
    #region Getters
    public SO_HeroPassivePerk PassivePerk { get { return passivePerk; } }
    public SO_HeroActivePerk ActivePerk { get { return activePerk; } }
    #endregion
}
