using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_CurrencyBase : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

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
        text.text = currencyArgs.currentBase.ToString("f0");
    }

}
