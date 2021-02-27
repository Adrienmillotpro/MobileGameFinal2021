using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipHeroes : MonoBehaviour
{
    [SerializeField] private ElementalTypes element;
    [SerializeField] private SO_Hero hero;
    [SerializeField] private GameObject heroUi;

    public static event Action<OnUpdateHeroesSlotsEventArgs> OnEquipHero;
    private OnUpdateHeroesSlotsEventArgs equipHeroArgs = new OnUpdateHeroesSlotsEventArgs();

    private void Awake()
    {
        HeroesSlots.OnUpdateHeroesSlots += OnUpdateHeroesSlotsDisplayOrNot;
    }

    private void OnDestroy()
    {
        HeroesSlots.OnUpdateHeroesSlots -= OnUpdateHeroesSlotsDisplayOrNot;
    }

    private void OnUpdateHeroesSlotsDisplayOrNot(OnUpdateHeroesSlotsEventArgs updateSlotArgs)
    {
        if (updateSlotArgs.slotType == this.element)
        {
            this.heroUi.SetActive(true);
        }
        else
        {
            this.heroUi.SetActive(false);
        } 
    }

    private void Start()
    {
        this.heroUi.SetActive(false);
        this.equipHeroArgs.equippedHero = this.hero;
    }

    public void EquipHero()
    {
        OnEquipHero?.Invoke(this.equipHeroArgs);
    }
}
