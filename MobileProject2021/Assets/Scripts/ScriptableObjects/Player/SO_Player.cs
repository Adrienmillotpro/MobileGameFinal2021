using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Player", menuName = "Player")]

public class SO_Player : ScriptableObject
{
    public SO_Hero[] playerHeroes = new SO_Hero[4];
    public SO_Gear[] playerHandGears = new SO_Gear[2];
    public SO_Gear[] playerAnkleGears = new SO_Gear[2];

    public float currencyElemental;
    public float currencyPremium;

    public void EndBattleUpdateCurrency(float premiumCurrency, float elementalCurrency)
    {
        currencyPremium += premiumCurrency;
        currencyElemental += elementalCurrency;
    }
}
