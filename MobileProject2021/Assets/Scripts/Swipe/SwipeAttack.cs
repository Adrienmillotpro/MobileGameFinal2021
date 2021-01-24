using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeAttack : MonoBehaviour
{

    void Update()
    {
        if (SwipeAttackMenu.swipeRight)
        {
            Debug.Log("Swipe Right Attack Menu");
            

        }

        if (SwipeAttackMenu.swipeLeft)
        {
            Debug.Log("Swipe left Attack Menu");


        }

        if (SwipeAttackMenu.swipeUp)
        {
            Debug.Log("Swipe Up Attack Menu");


        }
        if (SwipeAttackMenu.swipeDown)
        {
            Debug.Log("Swipe Down Attack Menu");


        }


    }
}
