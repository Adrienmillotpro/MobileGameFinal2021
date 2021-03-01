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
    [SerializeField] private TMP_Text gearLevel;


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
        this.gearLevel.text = this.equipSlot.Gear.gearLevel.ToString("F0");
        this.gearIcon.sprite = this.equipSlot.Gear.GearSprite;
    }
}
