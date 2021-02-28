using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EquipGearVisuals : MonoBehaviour
{
    [SerializeField] private EquipGear equipSlot;

    [SerializeField] private TMP_Text gearName;
    [SerializeField] private TMP_Text currentDamageText;
    [SerializeField] private TMP_Text currentAtkRateText;
    [SerializeField] private TMP_Text currentElemMultText;
    [SerializeField] private TMP_Text currentCurrMultText;

    private void OnEnable()
    {
        GearSlotsManager.OnUpdateGearSlot += OnUpdateSlotsUpdateEquipSlotVisuals;
    }

    private void OnDisable()
    {
        GearSlotsManager.OnUpdateGearSlot -= OnUpdateSlotsUpdateEquipSlotVisuals;
    }

    private void OnUpdateSlotsUpdateEquipSlotVisuals(OnUpdateGearEventArgs updateSlotsArgs)
    {
        gearName.text = equipSlot.Gear.GearName;
        currentDamageText.text = equipSlot.Gear.currentGearDamage.ToString();
        currentAtkRateText.text = equipSlot.Gear.currentGearAtkRate.ToString();
        currentElemMultText.text = equipSlot.Gear.currentGearElemMult.ToString();
        currentCurrMultText.text = equipSlot.Gear.currentGearCurrMult.ToString();
    }
}
