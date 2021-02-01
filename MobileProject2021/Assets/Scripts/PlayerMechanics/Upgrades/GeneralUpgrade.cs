using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralUpgrade : MonoBehaviour
{
    [SerializeField] protected float upgradeCostMultiplier;
    [SerializeField] protected float upgradeEffectMultiplier;
    protected int upgradeLevel;
    protected float upgradeCost;
    protected float upgradeEffect;
}
