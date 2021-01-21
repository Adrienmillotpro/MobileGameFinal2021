using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxBar(float bar)
    {
        slider.maxValue = bar;
        slider.value = bar;
    }




    public void SetBar(float bar)
    {
        slider.value = bar;
    }
}
