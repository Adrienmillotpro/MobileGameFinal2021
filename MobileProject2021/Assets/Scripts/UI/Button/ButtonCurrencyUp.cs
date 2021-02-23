using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonCurrencyUp : MonoBehaviour
{
    [SerializeField] private TMP_Text currentCurrency;
    [SerializeField] private TMP_Text nextCurrency;

    private void Awake()
    {
        UpgradeCurrencyMultiplier.OnUpgradeCurrMult += OnUpgradeCurrency;
    }

    private void OnDisable()
    {
        UpgradeCurrencyMultiplier.OnUpgradeCurrMult -= OnUpgradeCurrency;
    }

    private void OnUpgradeCurrency(OnUpgradeEventArgs upgradeEventArgs)
    {
        currentCurrency.text = upgradeEventArgs.upgradeEffect.ToString("f0");
        nextCurrency.text = upgradeEventArgs.nextUpgradeEffect.ToString("f0");

    }
}
