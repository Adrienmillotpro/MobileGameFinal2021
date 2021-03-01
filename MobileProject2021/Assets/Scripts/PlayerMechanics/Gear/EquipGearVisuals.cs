using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquipGearVisuals : MonoBehaviour
{
    [SerializeField] private EquipGear equipSlot;

    [SerializeField] private TMP_Text gearName;
    [SerializeField] private Image gearIcon;
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
        this.gearName.text = this.equipSlot.Gear.GearName;
        this.currentDamageText.text = this.equipSlot.Gear.currentGearDamage.ToString();
        this.currentAtkRateText.text = this.equipSlot.Gear.currentGearAtkRate.ToString();
        this.currentElemMultText.text = this.equipSlot.Gear.currentGearElemMult.ToString();
        this.currentCurrMultText.text = this.equipSlot.Gear.currentGearCurrMult.ToString();
        this.gearIcon.sprite = this.equipSlot.Gear.GearSprite;
    }
}
