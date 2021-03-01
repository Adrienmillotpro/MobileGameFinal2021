using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedHeroesVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHero;
   // [SerializeField] private SpriteRenderer heroSprite;

    private void OnEnable()
    {
       HeroesSlots.OnUpdateHeroesSlots += OnUpdateHeroSlotUpdateUi;
    }
    private void OnDisable()
    {
        HeroesSlots.OnUpdateHeroesSlots -= OnUpdateHeroSlotUpdateUi;
    }

    private void OnUpdateHeroSlotUpdateUi(OnUpdateHeroesSlotsEventArgs equipHeroArgs)
    {
        textHero.text = equipHeroArgs.equippedHero.HeroName;
        //heroSprite.sprite = equipHeroArgs.equippedHero.HeroSprite;

    }

}

