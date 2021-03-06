using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectedGearVisuals : MonoBehaviour
{
    [SerializeField] private SO_Gear selectedGear;

    [SerializeField] private TMP_Text gearName;
    [SerializeField] private Image gearIcon;

    [SerializeField] private TMP_Text currentDamageText;
    [SerializeField] private TMP_Text nextDamageText;

    [SerializeField] private TMP_Text currentAtkRateText;
    [SerializeField] private TMP_Text nextAtkRateText;

    [SerializeField] private TMP_Text currentElemMultText;
    [SerializeField] private TMP_Text nextElementMultText;

    [SerializeField] private TMP_Text currentCurrMultText;
    [SerializeField] private TMP_Text nextCurrMultText;

    [SerializeField] private TMP_Text currentCost;
    private void OnEnable()
    {
        GearSlotsManager.OnUpdateGearSlot += OnUpdateGearSlotUpdateSelectedGear;
    }

    private void OnDisable()
    {
        GearSlotsManager.OnUpdateGearSlot -= OnUpdateGearSlotUpdateSelectedGear;
    }

    private void OnUpdateGearSlotUpdateSelectedGear(OnUpdateGearEventArgs selectedGearSlotArgs)
    {
        selectedGear = selectedGearSlotArgs.so_equippedGear;

        gearName.text = selectedGear.GearName;
        gearIcon.sprite = selectedGear.GearSprite;

        currentDamageText.text = selectedGear.currentGearDamage.ToString();
        currentAtkRateText.text = selectedGear.currentGearAtkRate.ToString();
        currentElemMultText.text = selectedGear.currentGearElemMult.ToString();
        currentCurrMultText.text = selectedGear.currentGearCurrMult.ToString();

        nextDamageText.text = (selectedGear.GearDamage * (selectedGear.gearLevel +1) * selectedGear.gearTierMultiplier).ToString();
        nextAtkRateText.text = (selectedGear.GearAtkRate * (selectedGear.gearLevel + 1) * selectedGear.gearTierMultiplier).ToString();
        nextElementMultText.text = (selectedGear.GearElemMult * (selectedGear.gearLevel + 1) * selectedGear.gearTierMultiplier).ToString();
        nextCurrMultText.text = (selectedGear.GearCurrMult * (selectedGear.gearLevel + 1) * selectedGear.gearTierMultiplier).ToString();

        if (selectedGear.isAtTierCap)
        {
            currentCost.text = selectedGear.costToTierUp.ToString("F0");
        }
        else
        {
            currentCost.text = selectedGear.costToLevelUp.ToString("F0");
        }

    }
}
