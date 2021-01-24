using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UiSwipeBottom : MonoBehaviour
{
    public RectTransform mainMenu, secondMenu;
    public float speed = 0.30f;


    

    // Update is called once per frame
    void Update()
    {
        if (SwipeManager.swipeLeft)
        {
            Debug.Log("Swipe Left");
            mainMenu.DOAnchorPos(new Vector2(-1124, 179), speed);
            secondMenu.DOAnchorPos(new Vector2(0, 179), speed);
        }



        if (SwipeManager.swipeRight)
        {
            Debug.Log("Swipe Right");
            mainMenu.DOAnchorPos(new Vector2(0, 179), speed);
            secondMenu.DOAnchorPos(new Vector2(1124.5f, 179), speed);
        }

    


    }
}
