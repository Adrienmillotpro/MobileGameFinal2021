using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralUpgrade : MonoBehaviour
{
    [SerializeField] protected float baseUpgradeCost;
    [SerializeField] protected float upgradeCostMultiplier;
    [SerializeField] protected float baseUpgradeEffect;
    [SerializeField] protected float upgradeEffectMultiplier;
    protected float upgradeLevel;
    protected float currentUpgradeCost;
    protected float currentUpgradeEffect;
}
