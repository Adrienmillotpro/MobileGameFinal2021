using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GearSlotsManager : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;
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
        slotType = GearType.Hand;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedHandGear[0];
        OnUpdateGearSlot?.Invoke(gearArgs);
    }

    public void OnSeletRightHandSlot()
    {
        slotType = GearType.Hand;
        slotIndex = 1;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedHandGear[1];
        OnUpdateGearSlot?.Invoke(gearArgs);
    }

    public void OnSelectLeftHandSlot()
    {
        slotType = GearType.Hand;
        slotIndex = 0;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedHandGear[0];
        OnUpdateGearSlot?.Invoke(gearArgs);
    }

    public void OnSelectRightAnkleSlot()
    {
        slotType = GearType.Ankle;
        slotIndex = 1;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedAnkleGear[1];
        OnUpdateGearSlot?.Invoke(gearArgs);
    }

    public void OnSelectLeftAnkleSlot()
    {
        slotType = GearType.Ankle;
        slotIndex = 0;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedAnkleGear[0];
        OnUpdateGearSlot?.Invoke(gearArgs);
    }

    private void OnEquipGearUpdatePlayerGear(OnUpdateGearEventArgs equipGearArgs)
    {
        switch (equipGearArgs.gearType)
        {
            case GearType.Hand:
                equippedHandGear[slotIndex] = equipGearArgs.so_equippedGear;
                activePlayer.playerHandGears[slotIndex] = equipGearArgs.so_equippedGear;
                break;
            case GearType.Ankle:
                equippedAnkleGear[slotIndex] = equipGearArgs.so_equippedGear;
                activePlayer.playerAnkleGears[slotIndex] = equipGearArgs.so_equippedGear;
                break;
        }
    }
}
