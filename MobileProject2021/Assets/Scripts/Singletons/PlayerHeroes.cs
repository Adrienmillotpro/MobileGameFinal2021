using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHeroes : MonoBehaviour
{
    [SerializeField] private SO_Player activePlayer;

    private void OnEnable()
    {
        HeroesSlots.OnUpdateHeroesSlots += OnEquipHeroesUpdatePlayerHeroes;
    }

    private void OnDisable()
    {       
        HeroesSlots.OnUpdateHeroesSlots -= OnEquipHeroesUpdatePlayerHeroes;
    }

    public void OnEquipHeroesUpdatePlayerHeroes(OnUpdateHeroesSlotsEventArgs slotsArgs)
    {
        activePlayer.EquipHero(slotsArgs.equippedHero, slotsArgs.slotIndex);
    }

}
