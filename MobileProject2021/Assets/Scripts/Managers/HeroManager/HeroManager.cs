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

    public static event EventHandler<OnDamageEventArgs> OnClick;
    private OnDamageEventArgs damageArgs = new OnDamageEventArgs();

    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateHero;
        for (int i = 0; i < heroes.Length; i++)
        {
            heroesStats[i] = heroes[i].GetComponent<HeroStats>();
            heroesVisuals[i] = heroes[i].GetComponent<HeroVisuals>();
        }
        currentStats = heroesStats[0];
        currentVisuals = heroesVisuals[0];
    }
    private void OnDestroy()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateHero;
    }
    public void OnTapDealDamage()
    {
        if (OnClick != null)
        {
            this.damageArgs.damage = currentStats.heroDamage;
            this.damageArgs.damageTypes = currentStats.heroTypes;
            OnClick?.Invoke(this, damageArgs);
        }
    }
    private void OnSwapUpdateHero(object sender, OnSwapEventArgs swapArgs)
    {
        Debug.Log("I'm Updating Heroes");
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
        Debug.Log(currentStats.gameObject);
    }
}
