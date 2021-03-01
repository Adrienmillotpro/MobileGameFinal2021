using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPremiumCurrency : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;
    [SerializeField] private float realMoneyCost;
    [SerializeField] private float premiumCurrencyReward;
    [SerializeField] private Button shopButtonBuyPremium;

    public void BuyPremium()
    {
        activePlayer.currencyPremium += premiumCurrencyReward;
    }

}
