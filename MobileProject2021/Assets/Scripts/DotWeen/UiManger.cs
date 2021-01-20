using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UiManger : MonoBehaviour
{
    public RectTransform mainMenu, secondMenu, thirdMenu;
    public float speed = 0.30f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeManager.swipeRight)
        {
            Debug.Log("Swipe Right");
            mainMenu.DOAnchorPos(new Vector2(0, 0), speed);
            secondMenu.DOAnchorPos(new Vector2(1080, 0), speed);
        }

        if (SwipeManager.swipeLeft)
        {
            Debug.Log("Swipe Left");
            mainMenu.DOAnchorPos(new Vector2(-1080, 0), speed);
            secondMenu.DOAnchorPos(new Vector2(0, 0), speed);
        }



    }
}
