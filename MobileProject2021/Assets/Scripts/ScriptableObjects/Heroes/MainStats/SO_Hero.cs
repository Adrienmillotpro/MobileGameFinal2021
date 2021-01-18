using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Heroes", menuName = "Hero")]

public class SO_Hero : ScriptableObject
{
    [Header ("Hero Visuals")]
    public Sprite heroSprite;
    public Animator heroAnimator;

    [Header("Hero Stats")]
    public float heroDamage;
    public float heroAttackRate;
    public float heroElementalReactionMultiplier;
    public float heroCritRate;
    public float heroCritDamage;
    public float heroAffinityMultiplier;
    public float currencyMultiplier;

    public enum ElementType
    {
        Fire,
        Water,
        Air,
        Thunder
    }
    public ElementType[] heroTypes;

    [Header("Hero Perks")]
    public SO_HeroPassivePerk passivePerk;
    public SO_HeroActivePerk activePerk;
}
