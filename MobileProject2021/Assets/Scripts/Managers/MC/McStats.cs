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
        UpgradeDMG.OnUpgradeDMG += OnUpgradeDMGUpdateDMG;
        UpgradeAttackRate.OnUpgradeAttackRate += OnUpgradeAtkRateUpdateAtkRate;
        UpgradeElementalMultiplier.OnUpgradeElemMult += OnUpgradeElemMultUpdateElemUlt;
        UpgradeCurrencyMultiplier.OnUpgradeCurrMult += OnUpgradeCurrMultUpdateCurrMult;
    }
    private void OnDisable()
    {
        UpgradeDMG.OnUpgradeDMG -= OnUpgradeDMGUpdateDMG;
        UpgradeAttackRate.OnUpgradeAttackRate -= OnUpgradeAtkRateUpdateAtkRate;
        UpgradeElementalMultiplier.OnUpgradeElemMult -= OnUpgradeElemMultUpdateElemUlt;
        UpgradeCurrencyMultiplier.OnUpgradeCurrMult -= OnUpgradeCurrMultUpdateCurrMult;
    }

    private void OnUpgradeDMGUpdateDMG(OnUpgradeEventArgs upgradeArgs)
    {
        this.damage += upgradeArgs.upgradeEffect;
    }

    private void OnUpgradeAtkRateUpdateAtkRate(OnUpgradeEventArgs upgradeArgs)
    {
        this.rateOfAttack += upgradeArgs.upgradeEffect;
        if (this.rateOfAttack <= 0.3f)
        {
            this.rateOfAttack = 0.3f;
        }
    }

    private void OnUpgradeElemMultUpdateElemUlt(OnUpgradeEventArgs upgradeArgs)
    {
        this.elementalMultiplier += upgradeArgs.upgradeEffect;
    }

    private void OnUpgradeCurrMultUpdateCurrMult(OnUpgradeEventArgs upgradeArgs)
    {
        this.currencyMultiplier += upgradeArgs.upgradeEffect;
    }
}
