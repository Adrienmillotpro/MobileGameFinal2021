using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpGear : MonoBehaviour
{
    [SerializeField] SO_Player activePlayer;

    [SerializeField] private SO_Gear gear;
    [SerializeField] private Button buttonLevelUp;

    public static event Action<OnUpdateGearEventArgs> OnUpgradeGear;
    private OnUpdateGearEventArgs upgradeGearArgs = new OnUpdateGearEventArgs();

    private void OnEnable()
    {
        GearSlotsManager.OnUpdateGearSlot += OnUpdateGearSlotUpdateCurrentGear;
    }

    private void OnDisable()
    {
        GearSlotsManager.OnUpdateGearSlot -= OnUpdateGearSlotUpdateCurrentGear;
    }

    private void Update()
    {
        if (gear != null)
        {
            if (gear.isAtTierCap && activePlayer.currencyPremium < gear.costToTierUp)
            {
                buttonLevelUp.interactable = false;
            }
            else if (!gear.isAtTierCap && activePlayer.currencyElemental < gear.costToLevelUp)
            {
                buttonLevelUp.interactable = false;
            }
            else
            {
                buttonLevelUp.interactable = true;
            }
        }
    }

    private void OnUpdateGearSlotUpdateCurrentGear(OnUpdateGearEventArgs updateGearArgs)
    {
        gear = updateGearArgs.so_equippedGear;
        upgradeGearArgs.gearType = updateGearArgs.gearType;
    }

    public void GearUpgrade()
    {
        if (gear.isAtTierCap)
        {
            activePlayer.currencyPremium -= gear.costToTierUp;
            TierUp();
        }
        else
        {
            activePlayer.currencyElemental -= gear.costToLevelUp;
            LevelUp();
        }

        UpdateGearStats();
        OnUpgradeGear?.Invoke(upgradeGearArgs);
    }

    public void LevelUp()
    {
        gear.gearLevel++;
        for (int i = 0; i < gear.LvlCapForTier.Length; i++)
        {
            if (gear.gearLevel == gear.LvlCapForTier[i])
            {
                gear.isAtTierCap = true;
            }
        }
    }

    public void TierUp()
    {
        if (gear.gearTier != GearTier.Ancestral)
        {
            gear.gearTier = gear.gearTier + 1;
            gear.isAtTierCap = false;
        }
    }

    private void UpdateGearStats()
    {
        switch (gear.gearTier)
        {
            case GearTier.Respectable:
                gear.gearTierMultiplier = 1;
                break;
            case GearTier.Virtuous:
                gear.gearTierMultiplier = 2;
                break;
            case GearTier.Honorable:
                gear.gearTierMultiplier = 4;
                break;
            case GearTier.Ancestral:
                gear.gearTierMultiplier = 8;
                break;
        }

        gear.currentGearDamage = gear.GearDamage * gear.gearLevel * gear.gearTierMultiplier;
        gear.currentGearAtkRate = gear.GearAtkRate * gear.gearLevel * gear.gearTierMultiplier;
        gear.currentGearElemMult = gear.GearElemMult * gear.gearLevel * gear.gearTierMultiplier;
        gear.currentGearCurrMult = gear.GearCurrMult * gear.gearLevel * gear.gearTierMultiplier;

        gear.costToLevelUp = gear.GearBaseCost * Mathf.Pow(gear.gearTierMultiplier, gear.gearLevel);
        gear.costToTierUp = gear.GearBasePremiumCost * Mathf.Pow(gear.gearTierMultiplier, gear.gearLevel);
    }
}
