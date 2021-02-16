using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpgradeEventArgs : EventArgs
{
    public float currencyAmount;
    public float currencyBase;
    public float currencyPremium;
    public float currencyElemental;

    public float upgradeEffect;
    public float upgradeLevel;
    public float nextUpgradeEffect;
}
