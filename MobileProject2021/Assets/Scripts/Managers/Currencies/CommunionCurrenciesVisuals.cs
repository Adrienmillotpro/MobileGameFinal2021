using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommunionCurrenciesVisuals : MonoBehaviour
{
    [SerializeField] SO_Player activePlayer;
    [SerializeField] private TMP_Text textPremium;
    [SerializeField] private TMP_Text textElemental;
    [SerializeField] private float temp;

    private void Awake()
    {
        LevelUpGear.OnUpgradeGear += OnUpgradeGearUpdateCurrenciesUi;
    }

    private void OnDisable()
    {
        LevelUpGear.OnUpgradeGear -= OnUpgradeGearUpdateCurrenciesUi;
    }

    private void Start()
    {
        UpdatePreniumCurrencyUi();
        UpdateElementalCurrencyUi();
        Debug.Log(activePlayer.currencyPremium);
        Debug.Log(activePlayer.currencyElemental);
    }

    private void OnUpgradeGearUpdateCurrenciesUi(OnUpdateGearEventArgs onUpdateGearArgs)
    {
        UpdatePreniumCurrencyUi();
        UpdateElementalCurrencyUi();
        Debug.Log(activePlayer.currencyPremium);
        Debug.Log(activePlayer.currencyElemental);
    }

    private void UpdatePreniumCurrencyUi()
    {
        //if (activePlayer.currencyPremium >= 1000000)
        //{
        //    temp = activePlayer.currencyPremium / 1000000;
        //    textPrenium.text = temp.ToString("F1") + "M";
        //}

        //else if (activePlayer.currencyPremium >= 1000)
        //{
        //    temp = activePlayer.currencyPremium / 1000;
        //    textPrenium.text = temp.ToString("F1") + "K";
        //}
        //else
        //{
        //    temp = activePlayer.currencyPremium;
        //    textPrenium.text = temp.ToString("F1");
        //}
        textPremium.text = activePlayer.currencyPremium.ToString("F1");

    }

    private void UpdateElementalCurrencyUi()
    {
        //if (activePlayer.currencyElemental >= 1000000)
        //{
        //    temp = activePlayer.currencyElemental / 1000000;
        //    textElemental.text = temp.ToString("F1") + "M";
        //}

        //else if (activePlayer.currencyElemental >= 1000)
        //{
        //    temp = activePlayer.currencyPremium / 1000;
        //    textElemental.text = temp.ToString("F1") + "K";
        //}
        //else
        //{
        //    temp = activePlayer.currencyElemental;
        //    textElemental.text = temp.ToString("F1");
        //}

        textElemental.text = activePlayer.currencyElemental.ToString("F1");
    }
}
