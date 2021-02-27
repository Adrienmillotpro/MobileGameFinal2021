using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GearSlotsManager : MonoBehaviour
{
    private SO_Player activePlayer;

    private SO_Gear[] equippedHandGear = new SO_Gear[2];
    private SO_Gear[] equippedAnkleGear = new SO_Gear[2];
    private GearType slotType;
    private int slotIndex;

    public static event Action<OnUpdateGearEventArgs> OnUpdateGearSlot;
    private OnUpdateGearEventArgs gearArgs = new OnUpdateGearEventArgs();

    private void OnEnable()
    {
        EquipGear.OnEquipGear += OnEquipGearUpdatePlayerGear;
    }

    private void OnDisable()
    {
        EquipGear.OnEquipGear -= OnEquipGearUpdatePlayerGear;
    }

    private void Start()
    {
        slotIndex = 0;
    }

    public void OnSeletRightHandSlot()
    {
        slotType = GearType.Hand;
        slotIndex = 1;
    }

    public void OnSelectLeftHandSlot()
    {
        slotType = GearType.Hand;
        slotIndex = 0;
    }

    public void OnSelectRightAnkleSlot()
    {
        slotType = GearType.Ankle;
        slotIndex = 1;
    }

    public void OnSelectLeftAnkleSlot()
    {
        slotType = GearType.Ankle;
        slotIndex = 0;
    }

    private void OnEquipGearUpdatePlayerGear(OnUpdateGearEventArgs equipGearArgs)
    {
        switch (equipGearArgs.gearType)
        {
            case GearType.Hand:
                activePlayer.playerHandGears[slotIndex] = equipGearArgs.so_equippedGear;
                break;
            case GearType.Ankle:
                activePlayer.playerAnkleGears[slotIndex] = equipGearArgs.so_equippedGear;
                break;
        }
    }
}
