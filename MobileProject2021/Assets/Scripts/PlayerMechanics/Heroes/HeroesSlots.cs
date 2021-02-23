using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroesSlots : MonoBehaviour
{
    private ElementalTypes slotType;
    private GameObject[] equippedHero;
    private int slotIndex;
    private bool isSelected;

    public GameObject[] EquippedHero { get { return equippedHero; } }

    public void OnSelectFireSlot()
    {
        slotType = ElementalTypes.Fire;
        OnSelectSlotUpdateSlotIndex(slotType);
    }
    public void OnSelectWaterSlot()
    {
        slotType = ElementalTypes.Water;
        OnSelectSlotUpdateSlotIndex(slotType);
    }
    public void OnSelectAirSlot()
    {
        slotType = ElementalTypes.Air;
        OnSelectSlotUpdateSlotIndex(slotType);
    }
    public void OnSelectThunderSlot()
    {
        slotType = ElementalTypes.Thunder;
        OnSelectSlotUpdateSlotIndex(slotType);
    }

    private void OnSelectSlotUpdateSlotIndex(ElementalTypes selectedType)
    {
        if (selectedType == ElementalTypes.Fire)
        {
            slotIndex = 0;
        }
        if (selectedType == ElementalTypes.Air)
        {
            slotIndex = 1;
        }
        if (selectedType == ElementalTypes.Thunder)
        {
            slotIndex = 2;
        }
        if (selectedType == ElementalTypes.Water)
        {
            slotIndex = 3;
        }
    }
}
