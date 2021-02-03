using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralUpgrade : MonoBehaviour
{
    [SerializeField] protected int upgradeCostMultiplier;
    [SerializeField] protected int upgradeEffectMultiplier;
    protected int upgradeLevel;
    protected int upgradeCost;
    protected float upgradeEffect;
}
