using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpgradeEventArgs : EventArgs
{
    public float currencyAmount;
    public float currencyBase;
    public float currencyPremium;
    public float currencyFire;
    public float currencyThunder;
    public float currencyWater;
    public float currencyAir;

    public float upgradeEffect;
    public float upgradeLevel;
    public float nextUpgradeEffect;
}
