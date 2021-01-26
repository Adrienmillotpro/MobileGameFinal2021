using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    [SerializeField] private GameObject[] heroes = new GameObject[4];
    private HeroStats[] heroesStats = new HeroStats[4];
    private HeroStats currentStats;
    private HeroVisuals[] heroesVisuals = new HeroVisuals[4];
    private HeroVisuals currentVisuals;

    private bool isUp, isDown, isLeft, isRight;

    public static event Action<OnDamageEventArgs> OnClick;
    private OnDamageEventArgs damageArgs = new OnDamageEventArgs();

    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateHero;
        TapMechanic.OnTap += OnTapDealDamage;

        for (int i = 0; i < heroes.Length; i++)
        {
            heroesStats[i] = heroes[i].GetComponent<HeroStats>();
            heroesVisuals[i] = heroes[i].GetComponent<HeroVisuals>();
        }

    }

    private void Start()
    {
        currentStats = heroesStats[0];
        currentVisuals = heroesVisuals[0];
        heroesVisuals[1].enabled = false;
        heroesVisuals[2].enabled = false;
        heroesVisuals[3].enabled = false;
    }
    private void OnDestroy()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateHero;
        TapMechanic.OnTap -= OnTapDealDamage;
    }
    public void OnTapDealDamage(OnTapEventArgs tapArgs)
    {
        if (OnClick != null)
        {
            //Debug.Log("I received the Tap");
            this.damageArgs.damage = currentStats.heroDamage;
            this.damageArgs.damageTypes = currentStats.heroTypes;
            //Debug.Log("I'm sending this damage" + damageArgs.damage);
            OnClick?.Invoke(damageArgs);
        }
    }
    private void OnSwapUpdateHero(OnSwapEventArgs swapArgs)
    {
        //Debug.Log("I'm Updating Heroes");
        if (swapArgs.swipeUp && !isUp)
        {
            currentVisuals.enabled = false;
            isUp = true;
            isRight = false;
            isDown = false;
            isLeft = false;
            currentStats = heroesStats[0];
            currentVisuals = heroesVisuals[0];
            currentVisuals.enabled = true;
        }
        if (swapArgs.swipeRight && !isRight)
        {
            currentVisuals.enabled = false;
            isRight = true;
            isUp = false;
            isDown = false;
            isLeft = false;
            currentStats = heroesStats[1];
            currentVisuals = heroesVisuals[1];
            currentVisuals.enabled = true;
        }
        if (swapArgs.swipeDown && !isDown)
        {
            currentVisuals.enabled = false;
            isDown = true;
            isUp = false;
            isRight = false;
            isLeft = false;
            currentStats = heroesStats[2];
            currentVisuals = heroesVisuals[2];
            currentVisuals.enabled = true;
        }
        if (swapArgs.swipeLeft && !isLeft)
        {
            currentVisuals.enabled = false;
            isLeft = true;
            isUp = false;
            isRight = false;
            isDown = false;
            currentStats = heroesStats[3];
            currentVisuals = heroesVisuals[3];
            currentVisuals.enabled = true;
        }
        //Debug.Log(currentStats.heroDamage);
    }
}
