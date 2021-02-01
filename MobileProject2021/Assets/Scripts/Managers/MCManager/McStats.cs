using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McStats : MonoBehaviour
{
    public float damage;
    public float rateOfAttack;
    public float elementalMultiplier;
    public float currencyMultiplier;

    private void Awake()
    {
        UpgradeDMG.OnUpgradeDMG += OnUpgradeDMGUpdateStats;
    }
    private void OnDisable()
    {
        UpgradeDMG.OnUpgradeDMG -= OnUpgradeDMGUpdateStats;
    }

    private void OnUpgradeDMGUpdateStats(OnUpgradeEventArgs upgradeArgs)
    {
        this.damage += upgradeArgs.upgradeEffect;
    }
}
