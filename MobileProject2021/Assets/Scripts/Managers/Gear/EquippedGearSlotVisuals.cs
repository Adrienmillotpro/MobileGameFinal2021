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
    [SerializeField] private TMP_Text currentDamageText;
    [SerializeField] private TMP_Text currentAtkRateText;
    [SerializeField] private TMP_Text currentElemMultText;
    [SerializeField] private TMP_Text currentCurrMultText;

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
                currentDamageText.text = activePlayer.playerHandGears[slotIndex].currentGearDamage.ToString();
                currentAtkRateText.text = activePlayer.playerHandGears[slotIndex].currentGearAtkRate.ToString();
                currentElemMultText.text = activePlayer.playerHandGears[slotIndex].currentGearElemMult.ToString();
                currentCurrMultText.text = activePlayer.playerHandGears[slotIndex].currentGearCurrMult.ToString();
                gearIcon.sprite = activePlayer.playerHandGears[slotIndex].GearSprite;
                break;
            case GearType.Ankle:
                gearName.text = activePlayer.playerAnkleGears[slotIndex].GearName;
                currentDamageText.text = activePlayer.playerAnkleGears[slotIndex].currentGearDamage.ToString();
                currentAtkRateText.text = activePlayer.playerAnkleGears[slotIndex].currentGearAtkRate.ToString();
                currentElemMultText.text = activePlayer.playerAnkleGears[slotIndex].currentGearElemMult.ToString();
                currentCurrMultText.text = activePlayer.playerAnkleGears[slotIndex].currentGearCurrMult.ToString();
                gearIcon.sprite = activePlayer.playerAnkleGears[slotIndex].GearSprite;
                break;
        }
    }
}
