using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWheelFeedback : MonoBehaviour
{


    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateWheelFeedback;
    }

    private void OnDisable()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateWheelFeedback;
    }

    private void OnSwapUpdateWheelFeedback(OnSwapEventArgs swapArgs)
    {
        if (swapArgs.swipeUp)
        {

        }
        if (swapArgs.swipeRight)
        {

        }
        if (swapArgs.swipeDown)
        {

        }
        if (swapArgs.swipeLeft)
        {

        }
    }
}
