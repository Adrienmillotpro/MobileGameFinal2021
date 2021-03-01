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

    public void UpdatePreniumCurrencyUi()
    {
        if (activePlayer.currencyPremium >= 1000000f)
        {
            textPremium.text = (activePlayer.currencyPremium / 1000000f).ToString("F1") + "M";
        }
        else if (activePlayer.currencyPremium >= 1000f)
        {
            textPremium.text = (activePlayer.currencyPremium / 1000f).ToString("F1") + "K";
        }
        else
        {
            textPremium.text = activePlayer.currencyPremium.ToString("F1");
        }
    }

    public void UpdateElementalCurrencyUi()
    {
        if (activePlayer.currencyElemental >= 1000000f)
        {
            textElemental.text = (activePlayer.currencyElemental / 1000000f).ToString("F1") + "M";
        }
        else if (activePlayer.currencyElemental >= 1000f)
        {
            textElemental.text = (activePlayer.currencyElemental / 1000f).ToString("F1") + "K";
        }
        else
        {
            textElemental.text = activePlayer.currencyElemental.ToString("F1");
        }


    }
}
