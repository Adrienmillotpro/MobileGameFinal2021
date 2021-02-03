using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpgradeEventArgs : EventArgs
{
    public int currencyAmount;
    public int currencyBase;
    public int currencyPremium;
    public int currencyFire;
    public int currencyThunder;
    public int currencyWater;
    public int currencyAir;

    public float upgradeEffect;
    public float upgradeLevel;
    public float nextUpgradeEffect;
}
