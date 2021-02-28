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

    private void Awake()
    {
        equippedHandGear[0] = activePlayer.playerHandGears[0];
        equippedHandGear[1] = activePlayer.playerHandGears[1];
        equippedAnkleGear[0] = activePlayer.playerAnkleGears[0];
        equippedAnkleGear[1] = activePlayer.playerAnkleGears[1];

        activePlayer.playerHandGears[0].isEquipped = true;
        activePlayer.playerHandGears[1].isEquipped = true;
        activePlayer.playerAnkleGears[0].isEquipped = true;
        activePlayer.playerAnkleGears[1].isEquipped = true;
    }

    private void OnEnable()
    {
        EquipGear.OnEquipGear += OnEquipGearUpdatePlayerGear;
        LevelUpGear.OnUpgradeGear += OnUpgradeGearUpdatePlayerGear;
    }

    private void OnDisable()
    {
        EquipGear.OnEquipGear -= OnEquipGearUpdatePlayerGear;
        LevelUpGear.OnUpgradeGear -= OnUpgradeGearUpdatePlayerGear;
    }

    private void Start()
    {
        slotIndex = 0;
        slotType = GearType.Hand;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedHandGear[0];
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
    public void OnSeletRightHandSlot()
    {
        slotType = GearType.Hand;
        slotIndex = 1;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedHandGear[1];
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
    public void OnSelectRightAnkleSlot()
    {
        slotType = GearType.Ankle;
        slotIndex = 1;
        gearArgs.gearType = slotType;
        gearArgs.so_equippedGear = equippedAnkleGear[1];
        OnUpdateGearSlot?.Invoke(gearArgs);
    }

    private void OnEquipGearUpdatePlayerGear(OnUpdateGearEventArgs equipGearArgs)
    {
        switch (equipGearArgs.gearType)
        {
            case GearType.Hand:
                equippedHandGear[slotIndex].isEquipped = false;
                equippedHandGear[slotIndex] = equipGearArgs.so_equippedGear;
                activePlayer.playerHandGears[slotIndex] = equipGearArgs.so_equippedGear;
                equippedHandGear[slotIndex].isEquipped = true;
                break;
            case GearType.Ankle:
                equippedAnkleGear[slotIndex].isEquipped = false;
                equippedAnkleGear[slotIndex] = equipGearArgs.so_equippedGear;
                activePlayer.playerAnkleGears[slotIndex] = equipGearArgs.so_equippedGear;
                equippedAnkleGear[slotIndex].isEquipped = true;
                break;
        }
        gearArgs.so_equippedGear = equipGearArgs.so_equippedGear;
        OnUpdateGearSlot?.Invoke(gearArgs);
    }

    private void OnUpgradeGearUpdatePlayerGear(OnUpdateGearEventArgs upgradeGearArgs)
    {
        OnUpdateGearSlot?.Invoke(gearArgs);
    }
}
