using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterSwipeDirectionForTransition : MonoBehaviour
{
    [SerializeField] private SO_SwipeDirection so_Direction;

    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateTransitionType;
    }

    private void OnDisable()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateTransitionType;
    }

    private void OnSwapUpdateTransitionType(OnSwapEventArgs swapArgs)
    {
        if (swapArgs.swipeUp)
        {
            so_Direction.swipeType = SwipeType.Up;
        }
        if (swapArgs.swipeRight)
        {
            so_Direction.swipeType = SwipeType.Right;
        }
        if (swapArgs.swipeDown)
        {
            so_Direction.swipeType = SwipeType.Down;
        }
        if (swapArgs.swipeLeft)
        {
            so_Direction.swipeType = SwipeType.Left;
        }
    }
}
