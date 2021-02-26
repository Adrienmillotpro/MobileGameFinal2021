using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GearSlotsManager : MonoBehaviour
{
    private SO_Gear[] equippedGear = new SO_Gear[4];
    private GearType slotType;
    private int slotIndex;

    public static event Action<OnUpdateGearEventArgs> OnUpdateGear;
    private OnUpdateGearEventArgs gearArgs = new OnUpdateGearEventArgs();

    private void Start()
    {
        slotIndex = 0;
    }

    public void OnSeletRightHandSlot()
    {
        slotType = GearType.Hand;
        slotIndex = 0;
    }

    public void OnSelectLeftHandSlot()
    {
        slotType = GearType.Hand;
        slotIndex = 1;
    }

    public void OnSelectRightAnkleSlot()
    {
        slotType = GearType.Ankle;
        slotIndex = 2;
    }

    public void OnSelectLeftAnkleSlot()
    {
        slotType = GearType.Ankle;
        slotIndex = 3;
    }
}
