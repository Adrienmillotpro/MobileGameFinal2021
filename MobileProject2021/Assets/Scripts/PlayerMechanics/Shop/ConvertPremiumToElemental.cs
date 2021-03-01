using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertPremiumToElemental : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;
    [SerializeField] private float premiumCost;
    [SerializeField] private float elementalConversion;
    [SerializeField] private Button shopButtonConversion;

    private void Update()
    {
        if (this.premiumCost > activePlayer.currencyPremium)
        {
            this.shopButtonConversion.interactable = false;
        }
        else
        {
            this.shopButtonConversion.interactable = true;
        }
    }

    public void ConvertPremium()
    {
        activePlayer.currencyPremium -= premiumCost;
        activePlayer.currencyElemental += elementalConversion;
    }
}
