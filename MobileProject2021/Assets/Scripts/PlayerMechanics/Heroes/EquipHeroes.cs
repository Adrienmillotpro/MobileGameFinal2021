using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipHeroes : MonoBehaviour
{
    [SerializeField] private ElementalTypes element;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject heroUi;

    private HeroesSlots slots;

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
        if (updateSlotArgs.slotType == element)
        {
            heroUi.SetActive(true);
        }
        else
        {
            heroUi.SetActive(false);
        } 
    }

    private void Start()
    {
        slots = FindObjectOfType<HeroesSlots>();
    }

    public void EquipHero()
    {
        slots.EquipHero(hero);
        Debug.Log(hero);
    }
}
