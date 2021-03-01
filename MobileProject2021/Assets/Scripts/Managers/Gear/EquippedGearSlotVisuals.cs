using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquippedGearSlotVisuals : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;
    [SerializeField] private GearType slotType;
    [SerializeField] private int slotIndex;

    [SerializeField] private TMP_Text gearName;
    [SerializeField] private Image gearIcon;
    [SerializeField] private TMP_Text gearLevel;

    private void OnEnable()
    {
        GearSlotsManager.OnUpdateGearSlot += OnUpdateGearSlotsUpdateSlot;
    }

    private void OnDisable()
    {
        GearSlotsManager.OnUpdateGearSlot -= OnUpdateGearSlotsUpdateSlot;
    }

    private void OnUpdateGearSlotsUpdateSlot(OnUpdateGearEventArgs slotsArgs)
    {
        switch (slotType)
        {
            case GearType.Hand:
                gearName.text = activePlayer.playerHandGears[slotIndex].GearName;
                gearLevel.text = activePlayer.playerHandGears[slotIndex].gearLevel.ToString("F0");
                gearIcon.sprite = activePlayer.playerHandGears[slotIndex].GearSprite;
                break;
            case GearType.Ankle:
                gearName.text = activePlayer.playerAnkleGears[slotIndex].GearName;
                gearLevel.text = activePlayer.playerAnkleGears[slotIndex].gearLevel.ToString("F0");
                gearIcon.sprite = activePlayer.playerAnkleGears[slotIndex].GearSprite;
                break;
        }
    }
}
