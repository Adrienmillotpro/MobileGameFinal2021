using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UiManger : MonoBehaviour
{
    public RectTransform mainMenu, secondMenu, thirdMenu;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.50f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeManager.swipeRight)
        {
            Debug.Log("Swipe Right");
            mainMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
            secondMenu.DOAnchorPos(new Vector2(1080, 0), 0.50f);
        }

        if (SwipeManager.swipeLeft)
        {
            Debug.Log("Swipe Left");
            mainMenu.DOAnchorPos(new Vector2(-1080, 0), 0.50f);
            secondMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
        }



    }
}
