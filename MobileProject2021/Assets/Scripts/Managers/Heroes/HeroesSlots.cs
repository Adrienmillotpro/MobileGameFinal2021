using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroesSlots : MonoBehaviour
{
    private ElementalTypes slotType;
    private GameObject[] equippedHeroes = new GameObject[4];
    private int slotIndex;

    public GameObject[] EquippedHeroes { get { return equippedHeroes; } }

    public static event Action<OnUpdateHeroesSlotsEventArgs> OnUpdateHeroesSlots;
    private OnUpdateHeroesSlotsEventArgs onUpdateHeroesArgs = new OnUpdateHeroesSlotsEventArgs();

    private void OnEnable()
    {
        EquipHeroes.OnEquipHero += OnEquipHeroesUpdatePlayerHeroes;
    }

    private void OnDisable()
    {
        EquipHeroes.OnEquipHero -= OnEquipHeroesUpdatePlayerHeroes;
    }

    public void OnSelectFireSlot()
    {
        slotType = ElementalTypes.Fire;
        slotIndex = 0;
        onUpdateHeroesArgs.slotType = slotType;
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }
    public void OnSelectAirSlot()
    {
        slotType = ElementalTypes.Air;
        slotIndex = 1;
        onUpdateHeroesArgs.slotType = slotType;
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }
    public void OnSelectThunderSlot()
    {
        slotType = ElementalTypes.Thunder;
        slotIndex = 2;
        onUpdateHeroesArgs.slotType = slotType;
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }
    public void OnSelectWaterSlot()
    {
        slotType = ElementalTypes.Water;
        slotIndex = 3;
        onUpdateHeroesArgs.slotType = slotType;
    }

    private void OnEquipHeroesUpdatePlayerHeroes(OnUpdateHeroesSlotsEventArgs equipArgs)
    {
        onUpdateHeroesArgs.equippedHero = equipArgs.equippedHero;
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }

}
