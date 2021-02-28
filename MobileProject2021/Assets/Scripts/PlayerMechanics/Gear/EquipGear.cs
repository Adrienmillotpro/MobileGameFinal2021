using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipGear : MonoBehaviour
{
    [SerializeField] private SO_Gear gear;
    [SerializeField] private GameObject gearUi;
    [SerializeField] private Button gearEquipButton;
    public SO_Gear Gear { get { return gear; } }

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

        if (this.gear.isEquipped)
        {
            this.gearEquipButton.interactable = false;
        }
        else
        {
            this.gearEquipButton.interactable = true;
        }
    }

    public void Equip()
    {
        OnEquipGear?.Invoke(this.onEquipGearArgs);
    }
}
