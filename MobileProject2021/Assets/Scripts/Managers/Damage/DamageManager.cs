using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;
    [SerializeField] private McStats mcStats;
    [SerializeField] private HeroManager heroManager;
    [SerializeField] private EnemyManager enemyManager;

    private float gearAtkMultiplier;
    private float gearAtkRateMultiplier;
    private float gearElemMultiplier;
    private float gearCurrMultiplier;

    // Events
    public static event Action<OnDamageEventArgs> OnDealDamage;
    private OnDamageEventArgs onDealDamageArgs = new OnDamageEventArgs();

    private bool isInCooldown;

    private void Awake()
    {
        TapMechanic.OnTap += OnTapDealDamage;
        isInCooldown = false;
    }
    private void OnDisable()
    {
        TapMechanic.OnTap -= OnTapDealDamage;
    }

    private void Start()
    {
        for (int i = 0; i< activePlayer.playerHandGears.Length; i++)
        {
            gearAtkMultiplier += activePlayer.playerHandGears[i].currentGearDamage + activePlayer.playerAnkleGears[i].currentGearDamage;
            gearAtkRateMultiplier += activePlayer.playerHandGears[i].currentGearAtkRate + activePlayer.playerAnkleGears[i].currentGearAtkRate;
            gearElemMultiplier += activePlayer.playerHandGears[i].currentGearElemMult + activePlayer.playerAnkleGears[i].currentGearElemMult;
            gearCurrMultiplier += activePlayer.playerHandGears[i].currentGearCurrMult + activePlayer.playerAnkleGears[i].currentGearCurrMult;
        }
        gearAtkMultiplier /= 4;
        gearAtkRateMultiplier /= 4;
        gearElemMultiplier /= 4;
        gearCurrMultiplier /= 4;

    }

    private void Update()
    {
        if (mcStats.rateOfAttack != 0 && heroManager.CurrentStats.heroAttackRate != 0 && !isInCooldown)
        {
            AutoAttack();
        }
    }

    public void OnTapDealDamage(OnTapEventArgs tapArgs)
    {
        onDealDamageArgs.isAutoAttack = false;
        DealDamage();
    }

    private void CalculateDamage()
    {
        //Debug.Log("I'm calculating damage");
        float bestElementalReaction = new float();
        float elementalMultiplier = new float();
        ElementalTypes bestElementalType = new ElementalTypes();
        ElementalTypes weakElementalType = new ElementalTypes();

        for (int i = 0; i < enemyManager.CurrentSoEnemy.EnemyTypes.Length; i++)
        {
            for (int j = 0; j < heroManager.CurrentStats.heroTypes.Length; j++)
            {
                onDealDamageArgs.damageType = heroManager.CurrentStats.heroTypes[j];
                float newElementalReaction = TypeChart.DefineElementalReaction(heroManager.CurrentStats.heroTypes[j], enemyManager.CurrentSoEnemy.EnemyTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                    elementalMultiplier = bestElementalReaction;
                    bestElementalType = heroManager.CurrentStats.heroTypes[j];
                    weakElementalType = enemyManager.CurrentSoEnemy.EnemyTypes[i];
                }
            }
        }

        if (bestElementalReaction == 2)
        {
            elementalMultiplier = bestElementalReaction * heroManager.CurrentStats.heroElementalReactionMultiplier * mcStats.elementalMultiplier;
        }

        onDealDamageArgs.elementalMultiplier = elementalMultiplier;
        onDealDamageArgs.damage = (heroManager.CurrentStats.heroDamage + (mcStats.damage * gearAtkMultiplier)) * (elementalMultiplier * gearElemMultiplier);
        //Debug.Log("DealDamage - damageArgs.damage " + onDealDamageArgs.damage);

        onDealDamageArgs.enemyLevel = enemyManager.EnemyLevel;
        onDealDamageArgs.enemyMaxHealth = enemyManager.CurrentEnemyStats.EnemyMaxHealth;
        onDealDamageArgs.bestElementalReaction = bestElementalReaction;
        onDealDamageArgs.bestHeroElement = bestElementalType;
        onDealDamageArgs.weakEnemyElement = weakElementalType;
    }
    private void DealDamage()
    {
        CalculateDamage();
        OnDealDamage?.Invoke(onDealDamageArgs);
    }

    private void AutoAttack()
    {
        onDealDamageArgs.isAutoAttack = true;
        DealDamage();
        StartCoroutine(CooldownAutoAttack());
    }
    private IEnumerator CooldownAutoAttack()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(mcStats.rateOfAttack + heroManager.CurrentStats.heroAttackRate / 2);
        isInCooldown = false;
    }
}
