using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralUpgrade : MonoBehaviour
{
    public static Action<OnUpgradeEventArgs> OnUpgrade;

    [SerializeField] protected int upgradeCostMultiplier;
    protected float upgradeCost;
    protected float upgradeEffect;
}
