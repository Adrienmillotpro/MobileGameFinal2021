using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class SwipeIcone : MonoBehaviour
{
    public RectTransform popUp;
    public float speed = 0.30f;

    void Update()
    {
        if (SwipeManager.swipeRight)
        {
            Debug.Log("Swipe Right");

            popUp.DOAnchorPos(new Vector2(615, 456), speed);
        }

        if (SwipeManager.swipeLeft)
        {
            Debug.Log("Swipe Left");

            popUp.DOAnchorPos(new Vector2(446, 456), speed);
        }



    }















}
