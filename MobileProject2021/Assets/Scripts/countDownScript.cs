using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countDownScript : MonoBehaviour
{
    [SerializeField]
    private int StartCountDown = 60;

    [SerializeField]
    TextMeshProUGUI TxtCountDown;

     void Start()
    {
        
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        while(StartCountDown>0)
        {
            yield return new WaitForSeconds(1f);
            StartCountDown--;
            TxtCountDown.text = "TimeLeft : " + StartCountDown;
        }

        Debug.Log("You're dead");
    }
    


}


