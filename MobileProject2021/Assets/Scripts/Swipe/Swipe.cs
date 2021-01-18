using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public Transform ui;



    void Update()
    {
        if (SwipeManager.swipeRight)
        {
            Debug.Log("Swipe Right");
            ui.transform.position = ui.transform.position + new Vector3(100, 0, 0);

        }
        if (SwipeManager.swipeLeft)
        {
            Debug.Log("Swipe Left");
            ui.transform.position = ui.transform.position + new Vector3(-100, 0, 0);
        }
        if (SwipeManager.swipeUp)
        {
            Debug.Log("Swipe Up");
            ui.transform.position = ui.transform.position + new Vector3(0, 100, 0);
        }
        if (SwipeManager.swipeDown)
        {
            Debug.Log("Swipe Down");
            ui.transform.position = ui.transform.position + new Vector3(0, -100, 0);


        }


    }
}
