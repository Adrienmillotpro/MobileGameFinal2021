using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroesSlots : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;
    private SO_Hero[] equippedHeroes = new SO_Hero[4];

    private ElementalTypes slotType;
    private int slotIndex;

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

    private void Start()
    {
        for (int i = 0; i < equippedHeroes.Length; i++)
        {
            equippedHeroes[i] = activePlayer.playerHeroes[i];
        }
    }

    public void OnSelectFireSlot()
    {
        slotType = ElementalTypes.Fire;
        slotIndex = 0;
        onUpdateHeroesArgs.slotType = slotType;
        onUpdateHeroesArgs.equippedHero = equippedHeroes[0];
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }
    public void OnSelectAirSlot()
    {
        slotType = ElementalTypes.Air;
        slotIndex = 1;
        onUpdateHeroesArgs.slotType = slotType;
        onUpdateHeroesArgs.equippedHero = equippedHeroes[1];
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }
    public void OnSelectThunderSlot()
    {
        slotType = ElementalTypes.Thunder;
        slotIndex = 2;
        onUpdateHeroesArgs.slotType = slotType;
        onUpdateHeroesArgs.equippedHero = equippedHeroes[2];
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }
    public void OnSelectWaterSlot()
    {
        slotType = ElementalTypes.Water;
        slotIndex = 3;
        onUpdateHeroesArgs.slotType = slotType;
        onUpdateHeroesArgs.equippedHero = equippedHeroes[3];
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }

    private void OnEquipHeroesUpdatePlayerHeroes(OnUpdateHeroesSlotsEventArgs equipArgs)
    {
        equippedHeroes[slotIndex] = equipArgs.equippedHero;
        activePlayer.playerHeroes[slotIndex] = equipArgs.equippedHero;
        onUpdateHeroesArgs.equippedHero = equipArgs.equippedHero;
        OnUpdateHeroesSlots?.Invoke(onUpdateHeroesArgs);
    }


}
