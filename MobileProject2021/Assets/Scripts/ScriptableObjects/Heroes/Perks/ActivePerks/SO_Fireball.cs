using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Fireball", menuName = "Fireball")]

public class SO_Fireball : SO_HeroActivePerk
{
    public float PerkDamage;
    public override void ActivePerk()
    {
        // Event DMG enemy
        throw new System.NotImplementedException();
    }
}
