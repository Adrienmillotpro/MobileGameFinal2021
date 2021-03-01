using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommunionCurrenciesVisuals : MonoBehaviour
{
    [SerializeField] SO_Player activePlayer;
    [SerializeField] private TMP_Text textPrenium;
    [SerializeField] private TMP_Text textElemental;
    private float temp;

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
    }

    private void OnUpgradeGearUpdateCurrenciesUi(OnUpdateGearEventArgs onUpdateGearArgs)
    {
        UpdatePreniumCurrencyUi();
        UpdateElementalCurrencyUi();

    }

    private void UpdatePreniumCurrencyUi()
    {
        if (activePlayer.currencyPremium >= 1000000)
        {
            temp = activePlayer.currencyPremium / 1000000;
            textPrenium.text = temp.ToString("F1") + "M";
        }
        else if (activePlayer.currencyPremium >= 1000)
        {
            temp = activePlayer.currencyPremium / 1000;
            textPrenium.text = temp.ToString("F1") + "K";
        }
        else
        {
            temp = activePlayer.currencyPremium;
            textPrenium.text = temp.ToString("F1");
        }
        Debug.Log(activePlayer.currencyElemental);
    }

    private void UpdateElementalCurrencyUi()
    {
        if (activePlayer.currencyElemental >= 1000000)
        {
            temp = activePlayer.currencyElemental / 1000000;
            textElemental.text = temp.ToString("F1") + "M";
        }
        else if (activePlayer.currencyElemental >= 1000)
        {
            temp = activePlayer.currencyPremium / 1000;
            textElemental.text = temp.ToString("F1") + "K";
        }
        else
        {
            temp = activePlayer.currencyElemental;
            textElemental.text = temp.ToString("F1");
        }
        Debug.Log(activePlayer.currencyElemental);
    }
}
