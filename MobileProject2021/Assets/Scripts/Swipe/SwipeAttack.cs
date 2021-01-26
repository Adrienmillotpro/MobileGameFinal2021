using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeAttack : MonoBehaviour
{
    public GameObject Up;
    public GameObject Down;
    public GameObject left;
    public GameObject Right;

    public GameObject AIR;
    public GameObject FIRE;
    public GameObject WATER;
    public GameObject THUNDER;

    private void Awake()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateSwipe;
    }

    private void OnDestroy()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateSwipe;
    }

    private void OnSwapUpdateSwipe(object sender, OnSwapEventArgs swapArgs)
    {
        if (swapArgs.swipeRight)
        {
            Debug.Log("Swipe Right Attack Menu");
            Right.SetActive(true);
            left.SetActive(false);
            Up.SetActive(false);
            Down.SetActive(false);

            AIR.SetActive(true);
            FIRE.SetActive(false);
            WATER.SetActive(false);
            THUNDER.SetActive(false);
        }

        if (swapArgs.swipeLeft)
        {
            Debug.Log("Swipe left Attack Menu");
            Right.SetActive(false);
            left.SetActive(true);
            Up.SetActive(false);
            Down.SetActive(false);


            AIR.SetActive(false);
            FIRE.SetActive(true);
            WATER.SetActive(false);
            THUNDER.SetActive(false);
        }

        if (swapArgs.swipeUp)
        {
            Debug.Log("Swipe Up Attack Menu");
            Right.SetActive(false);
            left.SetActive(false);
            Up.SetActive(true);
            Down.SetActive(false);

            AIR.SetActive(false);
            FIRE.SetActive(false);
            WATER.SetActive(true);
            THUNDER.SetActive(false);
        }
        if (swapArgs.swipeDown)
        {
            Debug.Log("Swipe Down Attack Menu");
            Right.SetActive(false);
            left.SetActive(false);
            Up.SetActive(false);
            Down.SetActive(true);

            AIR.SetActive(false);
            FIRE.SetActive(false);
            WATER.SetActive(false);
            THUNDER.SetActive(true);
        }
    }
}
