using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_CurrencyBase : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private PlayerCurrencies currencies;
    private int currentAmount;

    private void Awake()
    {
        currencies = FindObjectOfType<PlayerCurrencies>();
    }


    void Update()
    {
        currentAmount = (int)currencies.CurrencyBase;
        text.text = currencies.CurrencyBase.ToString();
    }



}
