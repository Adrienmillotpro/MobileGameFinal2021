using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Ui_CurrencyElemental : MonoBehaviour
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
        //text.text = currencyArgs.currentElemental.ToString("f0");

        if (currencyArgs.currentElemental >= 1000000)
        {
            temp = currencyArgs.currentElemental / 1000000;
            text.text = temp.ToString("F1") + "M";
        }

        else if (currencyArgs.currentElemental >= 1000)
        {
            temp = currencyArgs.currentElemental / 1000;
            text.text = temp.ToString("F1") + "K";
        }
        else
        {
            temp = currencyArgs.currentElemental;
            text.text = temp.ToString("F1");
        }

    }
}

