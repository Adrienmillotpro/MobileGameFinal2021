using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public SO_Hero[] heroes = new SO_Hero[4];
    public SO_Hero currentHero;

    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateHero;
    }

    private void OnDestroy()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateHero;
    }

    private void OnSwapUpdateHero(object sender, OnSwapEventArgs swapArgs)
    {
        if (swapArgs.swipeUp)
        {
            currentHero = heroes[0];
        }

        if (swapArgs.swipeRight)
        {
            currentHero = heroes[1];
        }
        if (swapArgs.swipeDown)
        {
            currentHero = heroes[2];
        }
        if (swapArgs.swipeLeft)
        {
            currentHero = heroes[3];
        }
    }
}
