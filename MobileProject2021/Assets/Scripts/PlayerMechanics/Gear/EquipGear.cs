using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGear : MonoBehaviour
{
    [SerializeField] private SO_Gear gear;
    [SerializeField] private GameObject gearUi;

    public static event Action<OnUpdateGearEventArgs> OnEquipGear;
    private OnUpdateGearEventArgs onEquipGearArgs = new OnUpdateGearEventArgs();

    private void OnEnable()
    {
        GearSlotsManager.OnUpdateGearSlot += OnUpdateGearSlotUpdateUI;
    }

    private void OnDisable()
    {
        GearSlotsManager.OnUpdateGearSlot -= OnUpdateGearSlotUpdateUI;
    }

    private void Start()
    {
        this.onEquipGearArgs.so_equippedGear = this.gear;
        this.gearUi.SetActive(false);
    }

    public void OnUpdateGearSlotUpdateUI(OnUpdateGearEventArgs updateGearArgs)
    {
        if (updateGearArgs.gearType == this.gear.GearType)
        {
            this.gearUi.SetActive(true);
        }
        else
        {
            this.gearUi.SetActive(false);
        }
    }

    public void Equip()
    {
        OnEquipGear?.Invoke(this.onEquipGearArgs);
    }
}
