using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Player", menuName = "Player")]

public class SO_Player : ScriptableObject
{
    [SerializeField] private SO_Hero[] playerHeroes = new SO_Hero[4];
    [SerializeField] private SO_Gear[] playerGears = new SO_Gear[4];
    #region Getters
    public SO_Hero[] PlayerHeroes { get { return playerHeroes; } }
    public SO_Gear[] PlayerGears { get { return playerGears; } }
    #endregion

    private float currencyElemental;
    private float currencyPremium;
    #region Getters
    public float CurrencyElemental { get { return currencyElemental; } }
    public float CurrencyPremium { get { return currencyPremium; } }
    #endregion

    public void EquipHero(SO_Hero equippedHero, int index)
    {
        playerHeroes[index] = equippedHero;
    }

    public void CommunionUpdateCurrency(bool isPremium, float cost)
    {
        if (isPremium)
        {
            currencyPremium -= cost;
        }
        else
        {
            currencyElemental -= cost;
        }
    }

    public void EndBattleUpdateCurrency(float premiumCurrency, float elementalCurrency)
    {
        currencyPremium += premiumCurrency;
        currencyElemental += elementalCurrency;
    }

}
