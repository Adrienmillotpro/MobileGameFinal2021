using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWheelFeedback : MonoBehaviour
{
    [SerializeField] private GameObject[] shadedSymbols;
    [SerializeField] private GameObject[] nonShadedSymbols;

    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateWheelFeedback;
    }

    private void OnDisable()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateWheelFeedback;
    }

    private void Start()
    {
        for (int i = 0; i < shadedSymbols.Length; i++)
        {
            shadedSymbols[i].SetActive(false);
        }
        shadedSymbols[0].SetActive(true);
        nonShadedSymbols[0].SetActive(false);
    }

    private void OnSwapUpdateWheelFeedback(OnSwapEventArgs swapArgs)
    {
        for (int i = 0; i < shadedSymbols.Length; i++)
        {
            shadedSymbols[i].SetActive(false);
            nonShadedSymbols[i].SetActive(true);
        }

        if (swapArgs.swipeUp)
        {
            nonShadedSymbols[0].SetActive(false);
            shadedSymbols[0].SetActive(true);
        }
        if (swapArgs.swipeRight)
        {
            nonShadedSymbols[1].SetActive(false);
            shadedSymbols[1].SetActive(true);
        }
        if (swapArgs.swipeDown)
        {
            nonShadedSymbols[2].SetActive(false);
            shadedSymbols[2].SetActive(true);
        }
        if (swapArgs.swipeLeft)
        {
            nonShadedSymbols[3].SetActive(false);
            shadedSymbols[3].SetActive(true);
        }
    }
}
