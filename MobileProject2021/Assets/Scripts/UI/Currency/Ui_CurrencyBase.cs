using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_CurrencyBase : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float temp;



    private void Awake()
    {
        PlayerCurrencies.OnUpdateCurrency += OnUpdateCurrencyUpdateUI;
    }

    private void OnDisable()
    {
        PlayerCurrencies.OnUpdateCurrency -= OnUpdateCurrencyUpdateUI;
    }

    private void OnUpdateCurrencyUpdateUI(OnUpdateCurrenciesEventArgs currencyArgs)
    {
        //text.text = currencyArgs.currentBase.ToString("f0");

        if (currencyArgs.currentBase >= 1000000)
        {
            temp = currencyArgs.currentBase / 1000000;
            text.text = temp.ToString("F1") + "M";
        }

        else if(currencyArgs.currentBase >= 1000)
        {
            temp = currencyArgs.currentBase / 1000;
            text.text = temp.ToString("F1") + "K";
        }
        else
        {
            temp = currencyArgs.currentBase;
            text.text = temp.ToString("F1");
        }
        
        
        
    }

}
