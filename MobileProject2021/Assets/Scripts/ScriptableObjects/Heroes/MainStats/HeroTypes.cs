using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTypes : MonoBehaviour
{
    [SerializeField] private SO_Hero hero;

    [HideInInspector] public ElementalTypes[] heroTypes;

    private void Start()
    {
        this.heroTypes = hero.HeroTypes;
    }
}
