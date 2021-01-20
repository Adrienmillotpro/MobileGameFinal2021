using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FillAmount : MonoBehaviour
{
    public float maxBar = 1;
    public float startBar = 0.10f;
    public float currentBar;
   

    public BarScript barScript;

    private void Start()
    {
        currentBar = startBar;
        barScript.SetBar(startBar);
    }

    public void upgrade()
    {
        currentBar += 0.10f;
        barScript.SetBar(currentBar);
    }


}
