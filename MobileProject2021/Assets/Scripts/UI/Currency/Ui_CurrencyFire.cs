using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_CurrencyFire : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        PlayerCurrencies.OnUpdateCurrency += OnUpdateCurrencyUpdateUI;
    }

    private void OnDisable()
    {
        PlayerCurrencies.OnUpdateCurrency -= OnUpdateCurrencyUpdateUI;
    }

    private void OnUpdateCurrencyUpdateUI(OnUpdateCurrenciesEventArgs currenciesArgs)
    {
        text.text = currenciesArgs.currentFire.ToString();
    }

}
