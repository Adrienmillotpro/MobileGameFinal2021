using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;

    // Heroes Settings
    private GameObject[] heroes = new GameObject[4];
    private HeroStats[] heroesStats = new HeroStats[4];
    private HeroStats currentStats;
    private HeroVisuals[] heroesVisuals = new HeroVisuals[4];
    private HeroVisuals currentVisuals;
    #region Getters
    public HeroStats CurrentStats { get { return currentStats; } }
    public HeroVisuals CurrentVisuals { get { return currentVisuals; } }

    private bool isUp, isDown, isLeft, isRight;
    #endregion

    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateHero;;
    }

    private void Start()
    {

        for (int i = 0; i < heroes.Length; i++)
        {
            heroes[i] = Instantiate(activePlayer.PlayerHeroes[i].PrefabToInstantiate);
        }
        for (int i = 0; i < heroes.Length; i++)
        {
            heroesStats[i] = heroes[i].GetComponent<HeroStats>();
            heroesVisuals[i] = heroes[i].GetComponent<HeroVisuals>();
        }
        currentStats = heroesStats[0];
        currentVisuals = heroesVisuals[0];
        heroesVisuals[1].enabled = false;
        heroesVisuals[2].enabled = false;
        heroesVisuals[3].enabled = false;
    }
    private void OnDestroy()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateHero;
    }

    private void OnSwapUpdateHero(OnSwapEventArgs swapArgs) // Change currentHero OnSwap
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
