using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHealthTest : MonoBehaviour
{
    public Image image;
    public float imageNumber = 1f;
    public GameObject enemy;


    public void Tap()
    {
        image.fillAmount -= 0.02f;

        if (imageNumber == 0)
        {
            enemy.SetActive(false);



        }
              
              
    }

   
   
}
