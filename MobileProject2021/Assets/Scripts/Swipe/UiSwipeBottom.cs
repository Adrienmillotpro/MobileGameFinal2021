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
            mainMenu.DOAnchorPos(new Vector2(-714, 202), speed);
            secondMenu.DOAnchorPos(new Vector2(410, 202), speed);
        }


        if (SwipeManager.swipeRight)
        {
            mainMenu.DOAnchorPos(new Vector2(0, 202), speed);
            secondMenu.DOAnchorPos(new Vector2(1124.5f, 202), speed);
        }

    


    }
}
